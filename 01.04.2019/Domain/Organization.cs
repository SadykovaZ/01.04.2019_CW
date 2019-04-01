using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._04._2019.Domain
{
   // [Table("t_organizations")]
    public class OrganizationyType
    {
        #region Table properties
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        //[MaxLength(256)]
        //[Required]
        //[Column("org_type_name")]
        public string OrganizationTypeName { get; set; }
        #endregion
        #region Navigation properties
        public virtual ICollection<Organization> Organizations { get; set; }
        #endregion
    }
    public class Organization
    {
        #region Table properties
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string IdentificationNumber { get; set; }
        public Guid OrganizationTypeId { get; set; }        
        #endregion

        #region Navigation properties
        public OrganizationyType OrganizationyType { get; set; }

        #endregion

    }

    public class OrganizationyTypeConfiguration : EntityTypeConfiguration<OrganizationyType>
    {
        public OrganizationyTypeConfiguration()
        {
            ToTable("t_organizations");
            //создает первичный ключ таблицы
            HasKey(p => p.Id);
            //identity, свойство поля
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.OrganizationTypeName).IsRequired().HasMaxLength(256);//.HasColumnType("varchar");
                                                                                 //Property(p => p.OrganizationTypeName).HasColumnName("org_type_name");         
            //создание внещнего ключа, писать в родителе                                                                     
            HasMany(p => p.Organizations).WithRequired().HasForeignKey(p => p.OrganizationTypeId);


        }
    }

    public class OrganizationyConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationyConfiguration()
        {
            ToTable("t_organizations");
            //создает первичный ключ таблицы
            HasKey(p => p.Id);
            //identity, свойство поля
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.FullName).IsRequired().HasMaxLength(256);//.HasColumnType("varchar");
            //Property(p => p.OrganizationTypeName).HasColumnName("org_type_name");         
            Property(p => p.IdentificationNumber).IsRequired().HasMaxLength(256);//.HasColumnType("varchar");
            //HasRequired(p => p.OrganizationyType).WithMany(p => p.Organizations).HasForeignKey(p => p.OrganizationTypeId);


        }
    }

    public class ApplicationDBContext : DbContext
    {
        public DbSet<OrganizationyType> OrganizationyTypes { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrganizationyTypeConfiguration());
            modelBuilder.Configurations.Add(new OrganizationyConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        private readonly string _connection = ConfigurationManager.ConnectionStrings["" +
            "" +
            "" +
            "ApplicationDb2"].ConnectionString;

        public ApplicationDBContext():base("ApplicationDb2")
        {

        }

    }
}

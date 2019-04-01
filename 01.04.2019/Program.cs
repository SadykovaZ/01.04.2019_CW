using _01._04._2019.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._04._2019
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDBContext dBContext = new ApplicationDBContext();
            dBContext.Database.CreateIfNotExists();
            dBContext.OrganizationyTypes.Add(new OrganizationyType()
            {
                Id = Guid.Parse("828250CC-FF05-40E5-AB93-8B36091AF7F7"),
                OrganizationTypeName = "ТОО"
            });

            ApplicationDBContext dBContext = new ApplicationDBContext();
            dBContext.Organizations.Add(new Organization()
            {
                FullName="",
                IdentificationNumber="",
                

            });

            dBContext.SaveChanges();
        }
    }
}

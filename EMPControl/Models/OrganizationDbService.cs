using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPControl.Models
{
    static class OrganizationDbService
    {
        public static void Create(OrganizationModel model)
        {
            using (OrganizationsContext Db = new OrganizationsContext())
            {
                Db.Organizations.Add(model);
            }
        }

        public static List<OrganizationModel> Read()
        {
            using (OrganizationsContext Db = new OrganizationsContext())
            {
                var list = Db.Organizations.ToList();
                return list;
            }
        }

        public static void Update()
        {

        }

        public static void Delete(OrganizationModel model)
        {

        }
    }
}

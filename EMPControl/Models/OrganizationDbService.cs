using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace EMPControl.Models
{
    static class OrganizationDbService
    {
        public static void Create(OrganizationModel organizationModel)
        {
            using (OrganizationsContext Db = new OrganizationsContext())
            {
                try
                {
                    Db.Organizations.Add(organizationModel);
                    Db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static List<OrganizationModel> Read()
        {
            using (OrganizationsContext Db = new OrganizationsContext())
            {
                try
                {
                    var list = Db.Organizations.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return new List<OrganizationModel>();
                }
            }
        }

        public static void Update(OrganizationModel organizationModel)
        {
            using (OrganizationsContext Db = new OrganizationsContext())
            {
                try
                {
                    if (Db.Organizations.Find(organizationModel.Id) != null)
                    {
                        var currentOrganization = Db.Organizations.Find(organizationModel.Id);

                        if (currentOrganization != null)
                        {
                            currentOrganization.EquateModels(organizationModel);
                        }

                        Db.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void Delete(OrganizationModel organizationModel)
        {
            using (OrganizationsContext Db = new OrganizationsContext())
            {
                try
                {
                    Db.Organizations.Remove(organizationModel);
                    Db.SaveChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}

using System;
using System.Windows;

namespace EMPControl.Models
{

    //Статический класс для реализации CRUD-операций организаций для БД

    static class OrganizationDbService
    {

        //Создание нового объекта в БД

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

        //Считывание объектов из БД

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

        //Обновление объекта в БД

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

        //Удаление объекта в БД

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

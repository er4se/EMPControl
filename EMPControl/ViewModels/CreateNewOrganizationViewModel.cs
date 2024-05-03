using EMPControl.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EMPControl.ViewModels
{
    class CreateNewOrganizationViewModel : BindableBase
    {
        readonly OrganizationModel organizationModel;

        public string OrganizationName
        {
            get { return organizationModel.Name; }
            set
            {
                organizationModel.Name = value;
                RaisePropertyChanged(nameof(OrganizationName));
            }
        }

        public string OrganizationTIN
        {
            get { return organizationModel.TIN; }
            set
            {
                organizationModel.TIN = value;
                RaisePropertyChanged(nameof(OrganizationTIN));
            }
        }

        public string OrganizationLegalAddress
        {
            get { return organizationModel.LegalAddress; }
            set
            {
                organizationModel.LegalAddress += " ";
                organizationModel.LegalAddress += value;
                RaisePropertyChanged(nameof(OrganizationLegalAddress));
            }
        }

        public string OrganizationPhysicalAddress
        {
            get { return organizationModel.PhysicalAddress; }
            set
            {
                organizationModel.PhysicalAddress += " ";
                organizationModel.PhysicalAddress += value;
                RaisePropertyChanged(nameof(OrganizationPhysicalAddress));
            }
        }

        public CreateNewOrganizationViewModel()
        {
            organizationModel = new OrganizationModel();
            organizationModel.Id = Guid.NewGuid().ToString();

            CreateOrganization = new DelegateCommand(() =>
            {
                using(OrganizationsContext Db = new OrganizationsContext())
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

                MessageBox.Show("Организация добавлена!");
            });
        }

        public DelegateCommand CreateOrganization { get; }
    }
}

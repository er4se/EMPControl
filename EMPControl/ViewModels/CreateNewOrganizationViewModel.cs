using EMPControl.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EMPControl.ViewModels
{
    class CreateNewOrganizationViewModel : BindableBase
    {
        bool isAddressesNotEquals;

        readonly OrganizationModel organizationModel;

        readonly AddressModel legalAddress;
        readonly AddressModel physicalAddress;

        public bool IsAddressesNotEquals
        {
            get { return isAddressesNotEquals; }
            set 
            { 
                isAddressesNotEquals = value; 
                RaisePropertyChanged(nameof(IsAddressesNotEquals));
            }
        }

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

        #region "LegalAddressProperty"

        public string LegalAddressCountry
        {
            get { return legalAddress.Country; }
            set
            {
                legalAddress.Country = value;
                RaisePropertyChanged(nameof(LegalAddressCountry));
            }
        }

        public string LegalAddressRegion
        {
            get { return legalAddress.Region; }
            set
            {
                legalAddress.Region = value;
                RaisePropertyChanged(nameof(LegalAddressRegion));
            }
        }

        public string LegalAddressSettlement
        {
            get { return legalAddress.Settlement; }
            set
            {
                legalAddress.Settlement = value;
                RaisePropertyChanged(nameof(LegalAddressSettlement));
            }
        }

        public string LegalAddressStreet
        {
            get { return legalAddress.Street; }
            set
            {
                legalAddress.Street = value;
                RaisePropertyChanged(nameof(LegalAddressStreet));
            }
        }

        public string LegalAddressBuilding
        {
            get { return legalAddress.Building; }
            set
            {
                legalAddress.Building = value;
                RaisePropertyChanged(nameof(LegalAddressBuilding));
            }
        }

        public string LegalAddressOffice
        {
            get { return legalAddress.Office; }
            set
            {
                legalAddress.Office = value;
                RaisePropertyChanged(nameof(LegalAddressOffice));
            }
        }

        #endregion

        #region "PhysicalAddressProperty"

        public string PhysicalAddressCountry
        {
            get { return physicalAddress.Country; }
            set
            {
                physicalAddress.Country = value;
                RaisePropertyChanged(nameof(PhysicalAddressCountry));
            }
        }

        public string PhysicalAddressRegion
        {
            get { return physicalAddress.Region; }
            set
            {
                physicalAddress.Region = value;
                RaisePropertyChanged(nameof(PhysicalAddressRegion));
            }
        }

        public string PhysicalAddressSettlement
        {
            get { return physicalAddress.Settlement; }
            set
            {
                physicalAddress.Settlement = value;
                RaisePropertyChanged(nameof(PhysicalAddressSettlement));
            }
        }

        public string PhysicalAddressStreet
        {
            get { return physicalAddress.Street; }
            set
            {
                physicalAddress.Street = value;
                RaisePropertyChanged(nameof(PhysicalAddressStreet));
            }
        }

        public string PhysicalAddressBuilding
        {
            get { return physicalAddress.Building; }
            set
            {
                physicalAddress.Building = value;
                RaisePropertyChanged(nameof(PhysicalAddressBuilding));
            }
        }

        public string PhysicalAddressOffice
        {
            get { return physicalAddress.Office; }
            set
            {
                physicalAddress.Office = value;
                RaisePropertyChanged(nameof(PhysicalAddressOffice));
            }
        }

        #endregion

        public CreateNewOrganizationViewModel()
        {
            isAddressesNotEquals = false;

            organizationModel = new OrganizationModel();
            organizationModel.Id = Guid.NewGuid().ToString();

            legalAddress = new AddressModel();
            physicalAddress = new AddressModel();

            CreateOrganization = new DelegateCommand(() =>
            {
                organizationModel.LegalAddress = legalAddress.GetFullAddressString();

                if (isAddressesNotEquals)
                    organizationModel.PhysicalAddress = physicalAddress.GetFullAddressString();
                else
                    organizationModel.PhysicalAddress = legalAddress.GetFullAddressString();

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

                MessageBox.Show("Организация добавлена!");

                //Добавить сброс информации
            });
        }

        public DelegateCommand CreateOrganization { get; }
    }
}

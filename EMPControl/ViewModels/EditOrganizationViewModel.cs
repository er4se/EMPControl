using System;
using System.Windows;

using Prism.Commands;
using Prism.Mvvm;

using EMPControl.Models;

namespace EMPControl.ViewModels
{

    //ViewModel редактирование существующей организации

    class EditOrganizationViewModel : BindableBase
    {
        public DelegateCommand UpdateOrganizationCommand { get; }   //Команда обновления информации в БД

        readonly OrganizationModel organizationModel;               //Модель организации
        readonly AddressModel legalAddress;                         //Модель юр. адреса организации
        readonly AddressModel physicalAddress;                      //Модель физ. адреса организации

        //Открытые свойства для связи с View

        #region "public properties"

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

        #endregion

        //Конструктор для инициализации полей и команд

        public EditOrganizationViewModel(OrganizationModel incomingOrganizationModel)
        {
            this.organizationModel = incomingOrganizationModel;

            legalAddress = new AddressModel();
            legalAddress.ConvertStringToAddress(organizationModel.LegalAddress);

            physicalAddress = new AddressModel();
            physicalAddress.ConvertStringToAddress(organizationModel.PhysicalAddress);

            //Команда. Присвоение и стандартизация адресов, обновление объекта в БД, оповещение

            UpdateOrganizationCommand = new DelegateCommand(() =>
            {
                SetAddressToModel();
                OrganizationDbService.Update(organizationModel);

                MessageBox.Show("Данные организации изменены!");
            });
        }

        //Присвоение и стандартизация адресов

        private void SetAddressToModel()
        {
            organizationModel.LegalAddress = legalAddress.GetFullAddressString();
            organizationModel.PhysicalAddress = physicalAddress.GetFullAddressString();
        }
    }
}

using System;
using System.Windows;

using Prism.Commands;
using Prism.Mvvm;

using EMPControl.Models;

namespace EMPControl.ViewModels
{

    //ViewModel создание новой организации

    class CreateNewOrganizationViewModel : BindableBase
    {
        public DelegateCommand CreateOrganization { get; }      //Команда создания организации в БД

        bool isAddressesNotEquals;                              //Переключатель CheckBox

        readonly OrganizationModel organizationModel;           //Модель организации
        readonly AddressModel legalAddress;                     //Модель юр. адреса организации
        readonly AddressModel physicalAddress;                  //Модель физ. адреса организации

        //Открытые свойства для связи с View

        #region "public properties"

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

        #endregion

        //Конструктор для инициализации полей и команд

        public CreateNewOrganizationViewModel()
        {
            isAddressesNotEquals = false;

            organizationModel   = new OrganizationModel();
            legalAddress        = new AddressModel();
            physicalAddress     = new AddressModel();

            //Команда. Присвоение и стандартизация адресов, создание объекта в БД, сброс данных, оповещение

            CreateOrganization = new DelegateCommand(() =>
            {
                SetAddressToModel();
                OrganizationDbService.Create(organizationModel);
                organizationModel.ResetToDefault();
                
                MessageBox.Show("Организация добавлена!");

            });
        }

        //Присвоение и стандартизация адресов

        private void SetAddressToModel()
        {
            organizationModel.LegalAddress = legalAddress.GetFullAddressString();
            organizationModel.PhysicalAddress = isAddressesNotEquals ? physicalAddress.GetFullAddressString() : legalAddress.GetFullAddressString();
        }
    }
}

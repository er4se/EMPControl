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
        readonly OrganizationModel organizationModel;

        public ObservableCollection<string> legalAddressHolder;        //*
        public ObservableCollection<string> physicalAddressHolder;     //*

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

        public ObservableCollection<string> OrganizationLegalAddress
        {
            get { return legalAddressHolder; }
            set
            {
                legalAddressHolder = value;
                RaisePropertyChanged(nameof(OrganizationLegalAddress));
            }
        }


        public CreateNewOrganizationViewModel()
        {
            legalAddressHolder = new ObservableCollection<string>();        //*
            physicalAddressHolder = new ObservableCollection<string>();     //*

            organizationModel = new OrganizationModel();
            organizationModel.Id = Guid.NewGuid().ToString();
            

            CreateOrganization = new DelegateCommand(() =>
            {
                using(OrganizationsContext Db = new OrganizationsContext())
                {
                    try
                    {
                        //not working

                        organizationModel.LegalAddress = AddressHolderToString(legalAddressHolder);         //*
                        organizationModel.PhysicalAddress = AddressHolderToString(physicalAddressHolder);   //*

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

        private string AddressHolderToString(ObservableCollection<string> list)     //*
        {
            string finalValue = string.Empty;
            foreach (var item in list)
            {
                if (item == null)
                {
                    finalValue += (item + " ");
                }
            }

            MessageBox.Show(finalValue);

            return finalValue;
        }
    }
}

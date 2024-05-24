using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EMPControl.Models;
using EMPControl.Views;
using Prism.Commands;
using Prism.Mvvm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EMPControl.ViewModels
{
    class OrganizationControlViewModel : BindableBase
    {
        public Action CloseAction { get; set; }
        public ObservableCollection<OrganizationModel> organizations { get; set; }
        public OrganizationModel organization { get; set; }

        public OrganizationModel OrganizationModel      //перенести
        {
            get { return organization; }
            set
            {
                organization = value;
                RaisePropertyChanged(nameof(OrganizationModel));
            }
        }

        private BindableBase baseViewModel;

        public BindableBase BaseViewModel
        {
            get { return baseViewModel; }
            set
            {
                baseViewModel = value;
                RaisePropertyChanged(nameof(BaseViewModel));
            }
        }

        public ObservableCollection<OrganizationModel> Organizations
        {
            get { return organizations; }
            set
            {
                organizations = value;
                RaisePropertyChanged(nameof(Organizations));
            }
        }

        public OrganizationControlViewModel()
        {
            BaseViewModel = this;

            using (OrganizationsContext Db = new OrganizationsContext())
            {
                try
                {
                    var list = Db.Organizations.ToList();
                    Organizations = new ObservableCollection<OrganizationModel>(list);
                    //var list = Db.Organizations.FirstOrDefault();
                    //Organizations.Add(list);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

            MoveToCreate = new DelegateCommand(() =>
            {
                BaseViewModel = new CreateNewOrganizationViewModel();
            });

            MoveToEdit = new DelegateCommand(() =>
            {
                BaseViewModel = new EditOrganizationViewModel();
            });

            MoveToStart = new DelegateCommand(() =>
            {
                StartWindowView instance = new StartWindowView();
                instance.Show();

                CloseAction();
            });
        }

        public DelegateCommand MoveToCreate { get; }
        public DelegateCommand MoveToEdit { get; }
        public DelegateCommand MoveToStart { get; }
    }
}

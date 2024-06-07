using EMPControl.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPControl.ViewModels
{

    //ViewModel стартовое меню

    class StartWindowViewModel : BindableBase
    {
        public Action CloseAction { get; set; }

        public DelegateCommand MoveToOrganizationControl { get; }

        public StartWindowViewModel()
        {
            MoveToOrganizationControl = new DelegateCommand(() =>
            {
                OrganizationControlView instance = new OrganizationControlView();
                instance.Show();

                //CloseAction();
            });
        }

        
    }
}

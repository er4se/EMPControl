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
    class StartWindowViewModel : BindableBase
    {
        public Action CloseAction { get; set; }

        public StartWindowViewModel()
        {
            MoveToOrganizationControl = new DelegateCommand(() =>
            {
                OrganizationControlView instance = new OrganizationControlView();
                instance.Show();

                //CloseAction();
            });
        }

        public DelegateCommand MoveToOrganizationControl { get; }
    }
}

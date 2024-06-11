using EMPControl.Views;
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

    //ViewModel стартовое меню

    class StartWindowViewModel : BindableBase
    {
        public Action CloseAction { get; set; }

        public DelegateCommand MoveToOrganizationControl { get; }
        public DelegateCommand MoveToEmployeeControl { get; }
        public DelegateCommand MoveToCSVControl { get; }

        public StartWindowViewModel()
        {
            MoveToOrganizationControl = new DelegateCommand(() =>
            {
                OrganizationControlView instance = new OrganizationControlView();
                instance.Show();

                //CloseAction();
            });

            MoveToEmployeeControl = new DelegateCommand(() =>
            {
                MessageBox.Show("Разработка данного функционала программы заморожена\n" +
                    "\nПричина: важность pet-проектов на WPF под вопросом, кроме того функционал копирует существующий OrganizationControl\n" +
                    "\nИтог: возможно разработка продолжится в будущем", "ВНИМАНИЕ!");
            });

            MoveToCSVControl = new DelegateCommand(() =>
            {
                MessageBox.Show("Разработка данного функционала программы заморожена\n" +
                    "\nПричина: важность pet-проектов на WPF под вопросом\n" +
                    "\nИтог: возможно разработка продолжится в будущем", "ВНИМАНИЕ!");
            });
        }

        
    }
}

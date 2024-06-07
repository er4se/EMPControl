﻿using EMPControl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EMPControl.Views
{
    /// <summary>
    /// Логика взаимодействия для OrganizationControlView.xaml
    /// </summary>
    public partial class OrganizationControlView : Window
    {
        public OrganizationControlView()
        {
            InitializeComponent();

            OrganizationControlViewModel viewModel = new OrganizationControlViewModel();
            this.DataContext = viewModel;

            //if (viewModel.CloseAction == null)
            //{
            //    viewModel.CloseAction = new Action(this.Close);
            //}
        }
    }
}

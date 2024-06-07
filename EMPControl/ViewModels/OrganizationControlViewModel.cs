using System;
using System.Collections.ObjectModel;
using System.Windows;

using Prism.Commands;
using Prism.Mvvm;

using EMPControl.Models;

namespace EMPControl.ViewModels
{

    //ViewModel управление организациями

    class OrganizationControlViewModel : BindableBase
    {
        public DelegateCommand MoveToCreate { get; }                            //Команда перехода к созданию организации
        public DelegateCommand MoveToEdit { get; }                              //Команда перехода к редактированию организации
        public DelegateCommand MoveToStart { get; }                             //Команда возврата в главное меню
        public DelegateCommand LiqudateOrganization { get; }                    //Команда ликвидации организации
        public DelegateCommand RefreshOrganizationCollectionCommand { get; }    //Команда обновления списка организаций

        //public Action CloseAction { get; set; }

        private OrganizationModel organizationModel;                            //Модель организации
        private ObservableCollection<OrganizationModel> organizationsModels;    //Коллекция организаций
        private BindableBase baseViewModel;                                     //Экземпляр базового ViewModel

        //Открытые свойства для связи с View

        #region "public properties"

        public BindableBase BaseViewModel
        {
            get { return baseViewModel; }
            set
            {
                baseViewModel = value;
                RaisePropertyChanged(nameof(BaseViewModel));
            }
        }

        public OrganizationModel OrganizationModel
        {
            get { return organizationModel; }
            set
            {
                organizationModel = value;
                RaisePropertyChanged(nameof(OrganizationModel));
            }
        }

        public ObservableCollection<OrganizationModel> OrganizationsModels
        {
            get { return organizationsModels; }
            set
            {
                organizationsModels = value;
                RaisePropertyChanged(nameof(OrganizationsModels));
            }
        }

        #endregion

        //Конструктор для инициализации полей и команд

        public OrganizationControlViewModel()
        {
            organizationModel = new OrganizationModel();
            organizationsModels = new ObservableCollection<OrganizationModel>();

            baseViewModel = this;

            RefreshOrganizationCollection();

            //Команда. Апкаст базового ViewModel к Create

            MoveToCreate = new DelegateCommand(() =>
            {
                BaseViewModel = new CreateNewOrganizationViewModel();
            });

            //Команда. Апкаст базового ViewModel к edit, проверка на null

            MoveToEdit = new DelegateCommand(() =>
            {
                if (baseViewModel != null) BaseViewModel = new EditOrganizationViewModel(OrganizationModel);
                else MessageBox.Show("Не выбрана действующая организация");
            });

            //Команда. Возвращение к стартовому меню

            MoveToStart = new DelegateCommand(() =>
            {
                //Функционал в разработке
            });

            //Команда. Удаление объекта из БД, удаление объекта из коллекции, оповещение

            LiqudateOrganization = new DelegateCommand(() =>
            {
                if (OrganizationModel != null)
                {
                    var tempInfoString = OrganizationModel.Name;
                    OrganizationDbService.Delete(OrganizationModel);
                    OrganizationsModels.Remove(OrganizationModel);

                    MessageBox.Show("Организация " +  tempInfoString + " ликвидирована!");
                }
            });

            //Команда. Обновление списка организаций

            RefreshOrganizationCollectionCommand = new DelegateCommand(RefreshOrganizationCollection);
        }

        //Обновление списка организаций

        private void RefreshOrganizationCollection()
        {
            List<OrganizationModel> list = OrganizationDbService.Read();
            OrganizationsModels = new ObservableCollection<OrganizationModel>(list);
        }
    }
}

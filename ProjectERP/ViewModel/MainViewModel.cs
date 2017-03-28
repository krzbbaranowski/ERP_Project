using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using ProjectERP.Views;
using System;
using System.Windows.Controls;
using System.Windows.Threading;
using ProjectERP.Enums;
using ProjectERP.Factories;
using ProjectERP.Interfaces;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
using ProjectERP.ViewModel.Tables;
using CounterpartyTableView = ProjectERP.Views.Tables.CounterpartyTableView;
using ProjectERP.Utils.Helpers;
using ProjectERP.ViewModel.Details;

namespace ProjectERP.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _addCounterpartyCommand;
        private IContentView _contentView;

        private bool _addButtonVisible = false;
        private const string AddButtonVisiblePropertyName = "AddButtonVisible";
        public bool AddButtonVisible
        {
            get
            {
                return _addButtonVisible;
            }
            private set
            {
                Set(AddButtonVisiblePropertyName, ref _addButtonVisible, value);
            }

        }

        private bool _deleteButtonVisible = false;
        private const string DeleteButtonVisiblePropertyName = "DeleteButtonVisible";
        public bool DeleteButtonVisible
        {
            get
            {
                return _deleteButtonVisible;
            }
            private set
            {
                Set(DeleteButtonVisiblePropertyName, ref _deleteButtonVisible, value);
            }

        }

        public bool _saveButtonVisible;
        private const string SaveButtonVisiblePropertyName = "SaveButtonVisible";
        public bool SaveButtonVisible
        {
            get
            {
                return _saveButtonVisible;
            }
            private set
            {
                Set(SaveButtonVisiblePropertyName, ref _saveButtonVisible, value);
            }

        }

        public MainViewModel()
        {
            Messenger.Default.Register<ContentViewMessage>(this, SetCurrentContentView);
        }

        private void SetCurrentContentView(ContentViewMessage contentViewMessage)
        {
            _contentView = contentViewMessage.ContentView;

            AddButtonVisible = _contentView.CanAddItem;
            DeleteButtonVisible = _contentView.CanDeleteItem;
            SaveButtonVisible = _contentView.CanSaveItem;
        }

        public RelayCommand AddCounterpartyCommand
        {
            get
            {
                return _addCounterpartyCommand
                    ?? (_addCounterpartyCommand = new RelayCommand(
                    () =>
                    {
                        Dispatcher.CurrentDispatcher.BeginInvoke((Action) (() =>
                        {
                            CounterpartyTableViewModel view = ServiceLocator.Current.GetInstance<CounterpartyTableViewModel>();
                            MainTabItem tabItem = NewItemFactory.CreateClearMainTabItem(TabNameFactory.GeTabNameByType(view));

                            MainTabItemMessage tabItemMessage = new MainTabItemMessage
                            {
                                MainTabItem = tabItem
                            };

                            Messenger.Default.Send<MainTabItemMessage>(tabItemMessage, MessengerTokens.NewTabItemToAdd);
                        }));

                    }));
            }
        }
        
        private RelayCommand _addItemCommand;
        public RelayCommand AddItemCommand
        {
            get
            {
                return _addItemCommand
                    ?? (_addItemCommand = new RelayCommand(
                    () =>
                    {
                        MainTabItem newItem = NewItemFactory.CreateClearMainTabItem(TabNameFactory.GeTabNameByType(TabName.CounterpartyTab));
                        MainTabItemMessage newItemMessage = new MainTabItemMessage
                        {
                            MainTabItem = newItem,
                            IsNewContent = true
                        };

                        Messenger.Default.Send<MainTabItemMessage>(newItemMessage, MessengerTokens.NewTabItemToAdd);

                    }));
            }
        }

        private RelayCommand _saveItemCommand;
        public RelayCommand SaveItemCommand
        {
            get
            {
                return _saveItemCommand
                       ?? (_saveItemCommand = new RelayCommand(
                           () =>
                           {
                               _contentView.AddToDatabase();

                           }));
            }
        }

    }
}







            
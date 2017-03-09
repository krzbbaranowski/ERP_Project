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

        public MainViewModel()
        {
            Messenger.Default.Register<ContentViewMessage>(this, SetCurrentContentView);
        }

        private void SetCurrentContentView(ContentViewMessage contentViewMessage)
        {
            _contentView = contentViewMessage.ContentView;

            AddButtonVisible = _contentView.CanAddItem;
            DeleteButtonVisible = _contentView.CanDeleteItem;
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
                            MainTabItem tabItem = NewItemFactory.CreateClearMainTabItem(TabName.CounterpartyTabTable, null);

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

                        MainTabItem newItem = NewItemFactory.CreateClearMainTabItem(TabName.CounterpartyTab, null);
                        MainTabItemMessage newItemMessage = new MainTabItemMessage
                        {
                            MainTabItem = newItem
                        };

                        Messenger.Default.Send<MainTabItemMessage>(newItemMessage, MessengerTokens.NewTabItemToAdd);

                    }));
            }
        }

    }
}
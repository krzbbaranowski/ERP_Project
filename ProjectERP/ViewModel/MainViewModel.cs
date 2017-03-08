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
using ProjectERP.Interfaces;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
using ProjectERP.ViewModel.Tables;
using CounterpartyTableView = ProjectERP.Views.Tables.CounterpartyTableView;

namespace ProjectERP.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _addCounterpartyCommand;

        private IContentView _contentView;

        public MainViewModel()
        {
            Messenger.Default.Register<ContentViewMessage>(this, SetCurrentContentView);
        }

        private void SetCurrentContentView(ContentViewMessage contentViewMessage)
        {
            _contentView = contentViewMessage.ContentView;
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
                            MainTabItem tabItem = new MainTabItem
                            {
                                Header = "Kontrahenci",
                                Content = new CounterpartyTableView(),
                                TabType = TabType.Maintab

                            };

                            MainTabItemMessage tabItemMessage = new MainTabItemMessage
                            {
                                MainTabItem = tabItem
                            };

                            Messenger.Default.Send<MainTabItemMessage>(tabItemMessage);
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
                        Type viewType = _contentView.GetType();
                        object item = Convert.ChangeType(_contentView, viewType);

                        MainTabItem newItem = new MainTabItem
                        {
                            TabType = TabType.Subtab,
                     

                        };

                    }));
            }
        }

    }
}
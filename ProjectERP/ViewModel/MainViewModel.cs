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
using ProjectERP.Model.Messages;
using ProjectERP.ViewModel.Counterparties;
using ProjectERP.ViewModel.Interfaces;
using ProjectERP.ViewModel.UiControls;

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
                            CounterpartyTableModelView view = ServiceLocator.Current.GetInstance<CounterpartyTableModelView>();
                            MainTabItem tabItem = new MainTabItem
                            {
                                Header = "Kontrahenci",
                                Content = new CounterpartyTableView(),
                                TabType = TabType.Maintab

                            };

                            Messenger.Default.Send<MainTabItem>(tabItem);
                        }));

                    }));
            }
        }
        /* Header = $"Kontrahent {counterparty.Name1}",
                            TabType = TabType.Subtab,
                            Extra = counterparty*/

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
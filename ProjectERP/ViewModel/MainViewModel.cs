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


        public MainViewModel()
        {
         
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
                            MainTabItem tabItem = TabItemFactory.CreateClearMainTabItem(TabNameFactory.GeTabNameByType(view));

                            MainTabItemMessage tabItemMessage = new MainTabItemMessage
                            {
                                MainTabItem = tabItem
                            };

                            Messenger.Default.Send<MainTabItemMessage>(tabItemMessage, MessengerTokens.NewTabItemToAdd);
                        }));

                    }));
            }
        }

      
     

       

    }
}







            
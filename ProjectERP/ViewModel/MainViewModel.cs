using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using ProjectERP.Model.DataObjects;
using ProjectERP.Views;
using System;
using System.Windows.Threading;

namespace ProjectERP.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _addCounterpartyCommand;

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
                            CounterpartyModelView view = ServiceLocator.Current.GetInstance<CounterpartyModelView>();
                            MainTabItem tabItem = new MainTabItem
                            {
                                Header = "Kontrahenci",
                                Content = new CounterpartyView()

                            };

                            Messenger.Default.Send<MainTabItem>(tabItem);
                        }));

                    }));
            }
        }


        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}
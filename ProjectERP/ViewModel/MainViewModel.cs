using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using ProjectERP.Factories;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
using ProjectERP.Model.Repository.Interfaces;
using ProjectERP.Utils.Helpers;
using ProjectERP.ViewModel.Tables;

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
                               var view =
                                   SimpleIoc.Default.GetInstance<CounterpartyTableViewModel>();
                               MainTabItem tabItem =
                                   TabItemFactory.CreateClearMainTabItem(TabNameFactory.GetTabNameByType(view));

                               MainTabItemMessage tabItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem = tabItem
                               };

                               Messenger.Default.Send<MainTabItemMessage>(tabItemMessage,
                                   MessengerTokens.NewTabItemToAdd);


                           }));
            }
        }
    }
}







            
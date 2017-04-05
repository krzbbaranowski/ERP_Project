using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using ProjectERP.Factories;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
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
                               CounterpartyTableViewModel view =
                                   ServiceLocator.Current.GetInstance<CounterpartyTableViewModel>();
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







            
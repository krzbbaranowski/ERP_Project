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
using ProjectERP.ViewModel.Interfaces;
using ProjectERP.ViewModel.Tables;

namespace ProjectERP.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _addCounterpartyCommand;
        private RelayCommand _addArticleCommand;

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
                               IMainTabItem counterpartyTableVM =
                                   SimpleIoc.Default.GetInstance<CounterpartyTableViewModel>();

                               MainTabItemMessage tabItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem = counterpartyTableVM
                               };

                               Messenger.Default.Send<MainTabItemMessage>(tabItemMessage,
                                   MessengerTokens.NewTabItemToAdd);

                           }));
            }
        }



        public RelayCommand AddArticleCommand
        {
            get
            {
                return _addArticleCommand
                       ?? (_addArticleCommand = new RelayCommand(
                           () =>
                           {
                               IMainTabItem articleTableVM =
                                   SimpleIoc.Default.GetInstance<ArticleTableViewModel>();

                               MainTabItemMessage tabItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem = articleTableVM
                               };

                               Messenger.Default.Send<MainTabItemMessage>(tabItemMessage,
                                   MessengerTokens.NewTabItemToAdd);

                           }));
            }
        }
    }
}







            
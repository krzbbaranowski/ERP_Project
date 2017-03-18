using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Enums;
using ProjectERP.Interfaces;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
using ProjectERP.Utils.Helpers;
using ProjectERP.ViewModel.MVVMLight;

namespace ProjectERP.ViewModel.Controls.MainTab
{
    /// <summary>
    ///     Kontrolka z zakładkami. Zawiera inne widoki.
    /// </summary>
    public class MainTabViewModel : ViewModelBase
    {
        private RelayCommand<MainTabItem> _changeActiveTabCommand;
        private RelayCommand<MainTabItem> _closeCommand;

        public MainTabViewModel()
        {
            Tabs = new ObservableCollection<MainTabItem>();
            Messenger.Default.Register<MainTabItemMessage>(this, MessengerTokens.NewTabItemToAdd, AddTab);
        }

        public ObservableCollection<MainTabItem> Tabs { get; set; }

        public RelayCommand<MainTabItem> CloseCommand => _closeCommand
                                                         ?? (_closeCommand = new RelayCommand<MainTabItem>(
                                                             RemoveTab));

        public RelayCommand<MainTabItem> ChangeActiveTabCommand
        {
            get
            {
                return _changeActiveTabCommand
                       ?? (_changeActiveTabCommand = new RelayCommand<MainTabItem>(
                           item =>
                           {
                               if (item.Content.DataContext == null)
                                   return;
                               var contentView = (IContentView) item.Content.DataContext;

                               var contentViewMessage = new ContentViewMessage
                               {
                                   ContentView = contentView
                                  
                               };

                              Messenger.Default.Send(contentViewMessage);
                           }));
            }
        }


        private void RemoveTab(MainTabItem obj)
        {
            var itemToRemove = (from item in Tabs
                where item.Equals(obj)
                select item).FirstOrDefault();

            Tabs?.Remove(itemToRemove);
        }

        private void AddTab(MainTabItemMessage tab)
        {
            bool newContent = tab.IsNewContent;
            MainTabItem tabItemToAdd = tab.MainTabItem;
            if (!IsTabExists(tabItemToAdd))
            {
                if (tabItemToAdd.TabType == TabType.Maintab)
                    Tabs.Add(tabItemToAdd);

                if (tabItemToAdd.TabType == TabType.Subtab)
                {
                    var counterparty = tabItemToAdd.Extra as Counterparty;
                   
                    if (counterparty != null)
                    {
                        tabItemToAdd.Content = ViewModelLocator.CreateCounterpartyView(counterparty, newContent);
                        Tabs.Add(tabItemToAdd);
                    }
                }
            }
        }

        private bool IsTabExists(MainTabItem tab)
        {
            var isContains = (from t in Tabs
                where t.Header.Equals(tab.Header)
                select t).Any();

            return isContains;
        }
    }
}



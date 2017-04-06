using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Enums;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
using ProjectERP.Utils.Helpers;
using ProjectERP.ViewModel.MVVMLight;
using ProjectERP.Model.Enitites;

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
                           item => { }));
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
            var newContent = tab.IsNewContent;
            var tabToAdd = tab.MainTabItem;

            if (!IsTabExists(tabToAdd))
            {
                if (tabToAdd.TabType == TabType.Single)
                    Tabs.Add(tabToAdd);

                if (tabToAdd.TabType == TabType.Multiple)
                {
                    var counterparty = tabToAdd.Extra as Counterparty;

                    if (counterparty != null)
                    {
                        tabToAdd.Content = ViewModelLocator.CreateCounterpartyView(counterparty, newContent);
                        Tabs.Add(tabToAdd);
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
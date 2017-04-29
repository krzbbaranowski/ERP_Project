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
using ProjectERP.ViewModel.Interfaces;

namespace ProjectERP.ViewModel.Controls.MainTab
{
    /// <summary>
    ///     Kontrolka z zakładkami. Zawiera inne widoki.
    /// </summary>
    public class MainTabViewModel : ViewModelBase
    {
        private RelayCommand<IMainTabItem> _changeActiveTabCommand;
        private RelayCommand<IMainTabItem> _closeCommand;
        private IMainTabItem _currentTab = null;
        public MainTabViewModel()
        {
            Tabs = new ObservableCollection<IMainTabItem>();
            Messenger.Default.Register<MainTabItemMessage>(this, MessengerTokens.NewTabItemToAdd, AddTab);
            Messenger.Default.Register<MainTabItemMessage>(this, MessengerTokens.CloseTab, RemoveTab);
        }

        public ObservableCollection<IMainTabItem> Tabs { get; set; }

        public RelayCommand<IMainTabItem> ChangeActiveTabCommand
        {
            get
            {
                return _changeActiveTabCommand
                       ?? (_changeActiveTabCommand = new RelayCommand<IMainTabItem>(
                           item =>
                           {
                               if(_currentTab!=item)
                               {
                                   _currentTab = item;
                               }
                               else
                               {
                                   return;
                               }

                               if (item is IUpdateView)
                               {
                                   ((IUpdateView)item).UpdateView();;
                               }
                           

                           }));
            }
        }

        private void RemoveTab(MainTabItemMessage obj)
        {
            var itemToRemove = (from item in Tabs
                where item.Equals(obj.MainTabItem)
                select item).FirstOrDefault();

            Tabs?.Remove(itemToRemove);
        }

        private void AddTab(MainTabItemMessage tab)
        {
            IMainTabItem tabToAdd = tab.MainTabItem;

            if (!tabToAdd.IsMultiply)
                Tabs.Add(tabToAdd);

            if (tabToAdd.IsMultiply)
            {

                Tabs.Add(tabToAdd);

            }

        }

        private bool IsTabExists(IMainTabItem tab)
        {
            var isContains = (from t in Tabs
                where t.Header.Equals(tab.Header)
                select t).Any();

            return isContains;
        }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.Messages;
using ProjectERP.Utils.Helpers;
using ProjectERP.ViewModel.Interfaces;

namespace ProjectERP.ViewModel.Controls.MainTab
{
    /// <summary>
    ///     Kontrolka z zakładkami. Zawiera inne widoki.
    /// </summary>
    public class MainTabViewModel : ViewModelBase
    {
        private static readonly Dictionary<IMainTabItem, int> _ids = new Dictionary<IMainTabItem, int>();
        private RelayCommand<IMainTabItem> _changeActiveTabCommand;
        private RelayCommand<IMainTabItem> _closeCommand;
        private IMainTabItem _currentTab;

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
                               if (_currentTab != item)
                                   _currentTab = item;
                               else
                                   return;

                               if (item is IUpdateView)
                                   ((IUpdateView) item).UpdateView();
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
            var tabToAdd = tab.MainTabItem;

            AddId(tabToAdd);
            Tabs.Add(tabToAdd);

            ChangeActiveTabCommand.Execute(tabToAdd);
        }


        public bool TabExists(IMainTabItem tab)
        {
            var isEx = (from item in Tabs
                where item.Header.Equals(tab.Header)
                select item).Any();


            return isEx;
        }

        public bool AddId(IMainTabItem tab)
        {
            var nextId = 0;

            if (_ids.Count == 0)
                nextId = 1;
            else
                nextId = _ids.Values.Max() + 1;

            if (!_ids.ContainsKey(tab))
            {
                _ids.Add(tab, nextId);
                return true;
            }

            return false;
        }

        public int GetId(IMainTabItem tab)
        {
            return (from item in _ids
                where item.Key.Equals(tab)
                select item.Value).FirstOrDefault();
        }
    }
}
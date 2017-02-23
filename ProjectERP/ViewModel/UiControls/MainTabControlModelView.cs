using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Enums;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;

namespace ProjectERP.ViewModel.UiControls
{
    /// <summary>
    ///     Kontrolka z zakładkami. Zawiera inne widoki.
    /// </summary>
    public class MainTabControlModelView : ViewModelBase
    {
        private RelayCommand<UserControl> _addSubtabCommand;
        private RelayCommand<MainTabItem> _closeCommand;

        public MainTabControlModelView()
        {
            Tabs = new ObservableCollection<MainTabItem>();
            Messenger.Default.Register<MainTabItem>(this, AddTab);
        }

        public MainTabItem SelectedItem { get; set; }

        public ObservableCollection<MainTabItem> Tabs { get; set; }

        public RelayCommand<MainTabItem> CloseCommand => _closeCommand
                                                         ?? (_closeCommand = new RelayCommand<MainTabItem>(
                                                             RemoveTab));

        public RelayCommand<UserControl> AddSubtabCommand
        {
            get
            {
                return _addSubtabCommand
                       ?? (_addSubtabCommand = new RelayCommand<UserControl>(
                           newSubtab => { }));
            }
        }


        private void RemoveTab(MainTabItem obj)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke((Action) (() =>
            {
                var itemToRemove = (from item in Tabs
                    where item.Equals(obj)
                    select item).FirstOrDefault();

                Tabs?.Remove(itemToRemove);
            }));
        }

        private void AddTab(MainTabItem tab)
        {
            if (!IsExistsTab(tab) || (tab.TabType == TabType.Subtab))
            {
                Tabs.Add(tab);
                Counterparty counterparty = tab.Extra as Counterparty;
                if (counterparty != null)
                {
                    ViewModelLocator.CreateCounterpartyView(counterparty);
                }
                
               
            }
              
        }

        private bool IsExistsTab(MainTabItem tab)
        {
            var isContains = (from t in Tabs
                where t.Header.Equals(tab.Header)
                select t).Any();

            return isContains;
        }
    }
}
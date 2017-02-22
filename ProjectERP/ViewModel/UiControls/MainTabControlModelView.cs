using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;

namespace ProjectERP.ViewModel.UiControls
{
    /// <summary>
    ///     Kontrolka z zakładkami. Zawiera inne widoki.
    /// </summary>
    public class MainTabControlModelView : ViewModelBase
    {
        private RelayCommand<MainTabItem> _closeCommand;

        public MainTabControlModelView()
        {
            Tabs = new ObservableCollection<MainTabItem>();
            Messenger.Default.Register<MainTabItem>(this, AddTab);
        }

        public ObservableCollection<MainTabItem> Tabs { get; set; }

        public RelayCommand<MainTabItem> CloseCommand => _closeCommand
                                                         ?? (_closeCommand = new RelayCommand<MainTabItem>(
                                                             RemoveTab));

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

        private void AddTab(MainTabItem obj)
        {
            Tabs.Add(obj);
        }
    }
}
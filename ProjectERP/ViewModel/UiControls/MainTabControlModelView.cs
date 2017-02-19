using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
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
        public MainTabControlModelView()
        {
            Tabs = new ObservableCollection<MainTabItem>();
            Messenger.Default.Register<MainTabItem>(this, AddTab);
            Messenger.Default.Register<RemoveMainTabItemMessage>(this, RemoveTab);
        }

        public ObservableCollection<MainTabItem> Tabs { get; set; }


        private void RemoveTab(RemoveMainTabItemMessage obj)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke((Action) (() =>
            {
                var itemToRemove = (from item in Tabs
                    where item.Content.Equals(obj.Content)
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
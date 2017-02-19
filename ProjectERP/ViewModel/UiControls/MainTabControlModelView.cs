using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;

namespace ProjectERP.ViewModel.UiControls
{
    public class MainTabControlModelView : ViewModelBase
    {
        public ObservableCollection<MainTabItem> Tabs { get; set; }

        public MainTabControlModelView()
        {
            Tabs = new ObservableCollection<MainTabItem>();
            Messenger.Default.Register<MainTabItem>(this, AddTab);
            Messenger.Default.Register<RemoveMainTabItemMessage>(this, RemoveTab);
        }

        private void RemoveTab(RemoveMainTabItemMessage obj)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() =>
            {
                MainTabItem itemToRemove = (MainTabItem)(from item in Tabs
                    where item.Content.Equals(obj.Content)
                    select item).FirstOrDefault();

                Tabs?.Remove(itemToRemove);
            }));
        }

        private void AddTab(MainTabItem obj)
        {
          Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() =>
          {
              Tabs.Add(obj);
          }));
               
        }

       

        
    }
}
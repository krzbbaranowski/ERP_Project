using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.DataObjects;

namespace ProjectERP.ViewModel.UiControls
{
    public class MainTabControlModelView : ViewModelBase
    {
        private readonly object _sync = new object();
        public ObservableCollection<MainTabItem> Tabs { get; set; }

        public MainTabControlModelView()
        {
            Tabs = new ObservableCollection<MainTabItem>();
            Messenger.Default.Register<MainTabItem>(this, HandleMessage);
        }

    

        private void HandleMessage(MainTabItem obj)
        {
          Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() =>
          {
              Tabs.Add(obj);
          }));
               
        }
    }
}
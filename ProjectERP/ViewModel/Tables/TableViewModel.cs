#region

using System;
using System.Collections;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Enums;
using ProjectERP.Factories;
using ProjectERP.Model.Database;
using ProjectERP.Model.Messages;
using ProjectERP.Services;
using ProjectERP.Utils.Helpers;

#endregion

namespace ProjectERP.ViewModel.Tables
{
    public class TableViewModel : ViewModelBase
    {
        private readonly ERPDatabaseEntities _erpDatabase = ConnectionHelper.CreateConnection();
        private RelayCommand<object> _selectRowCommand;

        public TableViewModel(Type enityType)
        {
            var ex = typeof(DatabaseAccessService);
            var mi = ex.GetMethod("GetEntities");
            var miConstructed = mi.MakeGenericMethod(enityType);
            var itemList = miConstructed.Invoke(DatabaseAccessService.Current, null) as IList;

            if (itemList != null)
                foreach (var o in itemList)
                    Items.Add(o);
        }

        public ObservableCollection<object> Items { get; protected set; } = new ObservableCollection<object>();


        public RelayCommand<object> SelectRowCommand
        {
            get
            {
                return _selectRowCommand
                       ?? (_selectRowCommand = new RelayCommand<object>(
                           item =>
                           {
                               var tabItem = NewItemFactory.CreateClearMainTabItem(TabNameFactory.GeTabNameByType(item), item);
                               var tabItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem = tabItem,
                                   IsNewContent = false
                               };

                               Messenger.Default.Send(tabItemMessage, MessengerTokens.NewTabItemToAdd);
                           }));
            }
        }
    }
}
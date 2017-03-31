#region

using System;
using System.Collections;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Factories;
using ProjectERP.Model.Messages;
using ProjectERP.Services;
using ProjectERP.Utils.Helpers;

#endregion

namespace ProjectERP.ViewModel.Tables
{
    public class TableViewModel : ViewModelBase
    {
        private RelayCommand<object> _selectRowCommand;

        public TableViewModel(Type entityType)
        {
            Items = DatabaseAccessServiceClient.Current.GetEntities(entityType);
        }

        protected List<object> Items { get; set; } = new List<object>();


        public RelayCommand<object> SelectRowCommand
        {
            get
            {
                return _selectRowCommand
                       ?? (_selectRowCommand = new RelayCommand<object>(
                           item =>
                           {
                               var tabItem = TabItemFactory.CreateClearMainTabItem(
                                   TabNameFactory.GeTabNameByType(item), item);
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
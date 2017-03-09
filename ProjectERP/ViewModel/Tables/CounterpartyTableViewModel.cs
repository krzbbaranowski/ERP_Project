﻿#region

using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Enums;
using ProjectERP.Factories;
using ProjectERP.Interfaces;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
using ProjectERP.Services;
using ProjectERP.Utils.Helpers;

#endregion

namespace ProjectERP.ViewModel.Tables
{
    public class CounterpartyTableViewModel : ViewModelBase, IContentView
    {
        private readonly ERPDatabaseEntities _erpDatabase = ConnectionHelper.CreateConnection();
        private RelayCommand<object> _myCommand;

        public CounterpartyTableViewModel()
        {
            var list = _erpDatabase.Counterparty.ToList();
            Counterparties = new ObservableCollection<Counterparty>(list);
        }

        public ObservableCollection<Counterparty> Counterparties { get; }


        public RelayCommand<object> SelectRowCommand
        {
            get
            {
                return _myCommand
                       ?? (_myCommand = new RelayCommand<object>(
                           item =>
                           {
                               var tabItem = NewItemFactory.CreateClearMainTabItem(TabName.CounterpartyTab, item);

                               MainTabItemMessage tabItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem =  tabItem
                               };

                               Messenger.Default.Send(tabItemMessage, MessengerTokens.NewTabItemToAdd);
                           }));
            }
        }

        public bool CanAddItem => true;
        public bool CanDeleteItem => true;
    }
}
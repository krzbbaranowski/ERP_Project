#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Enums;
using ProjectERP.Factories;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
using ProjectERP.Utils.Helpers;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Repository.Interfaces;

#endregion

namespace ProjectERP.ViewModel.Tables
{
    public class CounterpartyTableViewModel : ViewModelBase
    {
        private readonly ICounterpartyRepository _counterpartyRepository;
        private RelayCommand _addItemCommand;
        private RelayCommand<MainTabItem> _deleteItemCommand;

        public CounterpartyTableViewModel(ICounterpartyRepository counterpartyRepository)
        {
            _counterpartyRepository = counterpartyRepository;

            Counterparties.Clear();
            IEnumerable<Counterparty> counterparties = _counterpartyRepository.GetEntities();

            Counterparties = new ObservableCollection<Counterparty>(counterparties);
        }

        public ObservableCollection<Counterparty> Counterparties { get; protected set; } =
            new ObservableCollection<Counterparty>();

        public RelayCommand AddItemCommand
        {
            get
            {
                return _addItemCommand
                       ?? (_addItemCommand = new RelayCommand(
                           () =>
                           {
                               var newItem =
                                   TabItemFactory.CreateClearMainTabItem(
                                       TabNameFactory.GetTabNameByType(TabName.CounterpartyTab));
                               var newItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem = newItem,
                                   IsNewContent = true
                               };

                               Messenger.Default.Send(newItemMessage, MessengerTokens.NewTabItemToAdd);
                           }));
            }
        }

        private RelayCommand<object> _selectRowCommand;

        public RelayCommand<object> SelectRowCommand
        {
            get
            {
                return _selectRowCommand
                       ?? (_selectRowCommand = new RelayCommand<object>(
                           item =>
                           {
                               var tabItem = TabItemFactory.CreateClearMainTabItem(
                                   TabNameFactory.GetTabNameByType(item), item);
                               var tabItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem = tabItem,
                                   IsNewContent = false
                               };

                               Messenger.Default.Send(tabItemMessage, MessengerTokens.NewTabItemToAdd);
                           }));
            }
        }

        public RelayCommand<MainTabItem> DeleteItemCommand
        {
            get
            {
                return _deleteItemCommand
                       ?? (_deleteItemCommand = new RelayCommand<MainTabItem>(
                           tab => { }));
            }
        }

        public void AddToDatabase()
        {
            throw new NotImplementedException();
        }

        public void DeleteToDatabase()
        {
            throw new NotImplementedException();
        }
    }
}
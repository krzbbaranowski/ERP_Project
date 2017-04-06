#region

using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Enums;
using ProjectERP.Factories;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
using ProjectERP.Utils.Helpers;
using ProjectERP.Model.Enitites;

#endregion

namespace ProjectERP.ViewModel.Tables
{
    public class CounterpartyTableViewModel : TableViewModel
    {
        private RelayCommand _addItemCommand;
        private RelayCommand<MainTabItem> _deleteItemCommand;

        public CounterpartyTableViewModel() : base(typeof(Counterparty))
        {
            Init();
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

        public RelayCommand<MainTabItem> DeleteItemCommand
        {
            get
            {
                return _deleteItemCommand
                       ?? (_deleteItemCommand = new RelayCommand<MainTabItem>(
                           tab => { }));
            }
        }

        private void Init()
        {
            Counterparties.Clear();
            foreach (var item in Items)
                Counterparties.Add((Counterparty) item);
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
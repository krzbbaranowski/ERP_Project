#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Enums;
using ProjectERP.Factories;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
using ProjectERP.Utils.Helpers;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Repository.Interfaces;
using ProjectERP.ViewModel.Details;
using ProjectERP.ViewModel.Interfaces;

#endregion

namespace ProjectERP.ViewModel.Tables
{
    public class CounterpartyTableViewModel : ViewModelBase, IMainTabItem
    {
        private readonly ICounterpartyRepository _counterpartyRepository;
        private RelayCommand _addItemCommand;
        private RelayCommand<Counterparty> _deleteItemCommand;

        public CounterpartyTableViewModel(ICounterpartyRepository counterpartyRepository)
        {
            _counterpartyRepository = counterpartyRepository;
            UpdateData();
        }

        private void UpdateData()
        {
            IEnumerable<Counterparty> counterparties = _counterpartyRepository.GetEntities();

            Counterparties.Clear();
            foreach (var counterparty in counterparties)
            {
                Counterparties.Add(counterparty);
            }
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
                               IMainTabItem counterpartyDetailsVM =
                                   SimpleIoc.Default.GetInstance<CounterpartyViewModel>(System.Guid.NewGuid().ToString());

                               var newItemMessage = new MainTabItemMessage
                               {
                                  MainTabItem = counterpartyDetailsVM
                               };

                               Messenger.Default.Send(newItemMessage, MessengerTokens.NewTabItemToAdd);
                           }));
            }
        }

        private RelayCommand<Counterparty> _selectRowCommand;

        public RelayCommand<Counterparty> SelectRowCommand
        {
            get
            {
                return _selectRowCommand
                       ?? (_selectRowCommand = new RelayCommand<Counterparty>(
                           item =>
                           {
                               IMainTabDetailsItem counterpartyDetailsVM =
                                   SimpleIoc.Default.GetInstance<CounterpartyViewModel>(System.Guid.NewGuid().ToString());

                               counterpartyDetailsVM.Initialize(item.Id);

                               var newItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem = counterpartyDetailsVM
                               };

                               Messenger.Default.Send(newItemMessage, MessengerTokens.NewTabItemToAdd);
                           }));
            }
        }

        public RelayCommand<Counterparty> DeleteItemCommand
        {
            get
            {
                return _deleteItemCommand
                       ?? (_deleteItemCommand = new RelayCommand<Counterparty>(
                           counterparty =>
                           {
                               Counterparty dbCounterparty = _counterpartyRepository.GetById(counterparty.Id);
                               _counterpartyRepository.Remove(dbCounterparty);
                               _counterpartyRepository.Save();

                               UpdateData();
                           }));
            }
        }

        public string Header { get; set; } = "Lista kontrahentów";
        public bool IsMultiply { get; set; } = false;
    }
}
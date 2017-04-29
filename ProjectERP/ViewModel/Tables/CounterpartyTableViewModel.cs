#region

using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.Enitites;
using ProjectERP.Model.Messages;
using ProjectERP.Model.Repository.Interfaces;
using ProjectERP.Utils.Helpers;
using ProjectERP.ViewModel.Details;
using ProjectERP.ViewModel.Interfaces;

#endregion

namespace ProjectERP.ViewModel.Tables
{
    public class CounterpartyTableViewModel : ViewModelBase, IMainTabItem, IUpdateView
    {
        private readonly ICounterpartyRepository _counterpartyRepository;
        private RelayCommand _addItemCommand;
        private RelayCommand<Counterparty> _deleteItemCommand;

        private RelayCommand<Counterparty> _selectRowCommand;
        private RelayCommand _closeCommand;

        public CounterpartyTableViewModel(ICounterpartyRepository counterpartyRepository)
        {
            _counterpartyRepository = counterpartyRepository;
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
                                   SimpleIoc.Default.GetInstance<CounterpartyViewModel>(Guid.NewGuid().ToString());

                               var newItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem = counterpartyDetailsVM
                               };

                               Messenger.Default.Send(newItemMessage, MessengerTokens.NewTabItemToAdd);
                           }));
            }
        }

        public RelayCommand CloseCommand => _closeCommand
                                            ?? (_closeCommand = new RelayCommand(
                                                () =>
                                                {
                                                    var newItemMessage = new MainTabItemMessage
                                                    {
                                                        MainTabItem = this
                                                    };

                                                    Messenger.Default.Send(newItemMessage, MessengerTokens.CloseTab);
                                                }));


        public RelayCommand<Counterparty> SelectRowCommand
        {
            get
            {
                return _selectRowCommand
                       ?? (_selectRowCommand = new RelayCommand<Counterparty>(
                           item =>
                           {
                               if (item == null)
                                   return;

                               IMainTabDetailsItem counterpartyDetailsVM =
                                   SimpleIoc.Default.GetInstance<CounterpartyViewModel>(Guid.NewGuid().ToString());

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
                               var dbCounterparty = _counterpartyRepository.GetById(counterparty.Id);
                               _counterpartyRepository.Remove(dbCounterparty);
                               _counterpartyRepository.Save();

                               UpdateView();
                           }));
            }
        }

        public string Header { get; set; } = "Lista kontrahentów";
        public bool IsMultiply { get; set; } = false;

        public void UpdateView()
        {
            var counterparties = _counterpartyRepository.GetEntities();

            Counterparties.Clear();
            foreach (var counterparty in counterparties)
                Counterparties.Add(counterparty);
        }
    }
}


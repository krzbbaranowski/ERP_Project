#region

using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Enums;
using ProjectERP.Interfaces;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Messages;
using ProjectERP.Services;

#endregion

namespace ProjectERP.ViewModel.Tables
{
    public class CounterpartyTableViewModel : ViewModelBase, IContentView
    {
        private readonly ERPDatabaseEntities _erpDatabase = ConnectionHelper.CreateConnection();
        private RelayCommand<Counterparty> _myCommand;

        public CounterpartyTableViewModel()
        {
            var list = _erpDatabase.Counterparty.ToList();
            Counterparties = new ObservableCollection<Counterparty>(list);
        }

        public ObservableCollection<Counterparty> Counterparties { get; }


        public RelayCommand<Counterparty> SelectRowCommand
        {
            get
            {
                return _myCommand
                       ?? (_myCommand = new RelayCommand<Counterparty>(
                           counterparty =>
                           {
                               var tabItem = new MainTabItem
                               {
                                   Header = $"Kontrahent {counterparty.Name1}",
                                   TabType = TabType.Subtab,
                                   Extra = counterparty
                               };

                               MainTabItemMessage tabItemMessage = new MainTabItemMessage
                               {
                                   MainTabItem =  tabItem
                               };

                               Messenger.Default.Send(tabItemMessage);
                           }));
            }
        }

        public bool CanAddItem => true;
    }
}
#region

using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Enums;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;
using ProjectERP.Services;
using ProjectERP.Views;

#endregion

namespace ProjectERP.ViewModel.Counterparties
{
    public class CounterpartyTableModelView : ViewModelBase
    {
        private readonly ERPDatabaseEntities _erpDatabase = ConnectionHelper.CreateConnection();

        private RelayCommand<Counterparty> _myCommand;

        public CounterpartyTableModelView()
        {
            var list = _erpDatabase.Counterparty.ToList();
            Counterparties = new ObservableCollection<Counterparty>(list);
        }

        public ObservableCollection<Counterparty> Counterparties { get; }

        /// <summary>
        ///     Gets the MyCommand.
        /// </summary>
        public RelayCommand<Counterparty> SelectedRowCommand
        {
            get
            {
                return _myCommand
                       ?? (_myCommand = new RelayCommand<Counterparty>(
                           counterparty =>
                           {
                               var tabItem = new MainTabItem
                               {
                                   Header = "Karta kontrahenci",
                                   TabType = TabType.Subtab,
                                   Extra = counterparty
                               };
                               Messenger.Default.Send(tabItem);

                           }));
            }
        }
    }
}
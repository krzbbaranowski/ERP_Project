#region

using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.Database;
using ProjectERP.Services;

#endregion

namespace ProjectERP.ViewModel.Counterparties
{
    public class CounterpartyTableModelView : ViewModelBase
    {
        private readonly ERPDatabaseEntities _erpDatabase = ConnectionHelper.CreateConnection();

        public CounterpartyTableModelView()
        {
            var list = _erpDatabase.Counterparty.ToList();
            Counterparties = new ObservableCollection<Model.Database.Counterparty>(list);
        }

        public ObservableCollection<Model.Database.Counterparty> Counterparties { get; }

        private RelayCommand<Counterparty> _myCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand<Counterparty> SelectedRowCommand
        {
            get
            {
                return _myCommand
                    ?? (_myCommand = new RelayCommand<Counterparty>(
                    p =>
                    {
                        Counterparty cp = new Counterparty
                        {
                            Name1 = p.Name1
                        };
                        Messenger.Default.Send(cp);
                    }));
            }
        }
       
    }
}
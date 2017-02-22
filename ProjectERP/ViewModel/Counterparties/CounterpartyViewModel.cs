using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.Database;
using ProjectERP.Services;

namespace ProjectERP.ViewModel.Counterparties
{
    public class CounterpartyViewModel : ViewModelBase
    {
        public const string CounterPartyStr = "CounterpartyName";
        private readonly ERPDatabaseEntities _erpDatabase = ConnectionHelper.CreateConnection();
        private Counterparty _counterparty;
        private string _counterpartyName;

        public CounterpartyViewModel()
        {
            var list = _erpDatabase.Counterparty.ToList();
            Counterparties = new ObservableCollection<Counterparty>(list);

            Messenger.Default.Register<Counterparty>(this, ProcessItem);
        }

        public ObservableCollection<Counterparty> Counterparties { get; private set; }

        public string CounterpartyName
        {
            get { return _counterpartyName; }
            set { Set(CounterPartyStr, ref _counterpartyName, value); }
        }

        private void ProcessItem(Counterparty counterparty)
        {
            _counterparty = counterparty;
            CounterpartyName = _counterparty.Name1;
        }
    }
}
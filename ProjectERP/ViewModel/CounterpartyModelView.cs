#region

using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using System.Linq;
using ProjectERP.Model.Database;

#endregion

namespace ProjectERP.ViewModel
{
    public class CounterpartyModelView : ViewModelBase
    {
        public ObservableCollection<Counterparty> Counterparties { get; }

        public CounterpartyModelView()
        {
            var db = new ERPDatabaseEntities();

            var list = (from cp in db.Counterparty
                select cp);

            Counterparties = new ObservableCollection<Counterparty>(list);
        }
    }
}
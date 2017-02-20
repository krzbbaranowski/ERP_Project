#region

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProjectERP.Model.Database;
using ProjectERP.Model.Messages;

#endregion

namespace ProjectERP.ViewModel
{
    public class CounterpartyModelView : ViewModelBase
    {
      


        public CounterpartyModelView()
        {
            var db = new ERPDatabaseEntities();

            var list = from cp in db.Counterparty
                select cp;

            Counterparties = new ObservableCollection<Counterparty>(list);
        }

        public ObservableCollection<Counterparty> Counterparties { get; }

    }
}
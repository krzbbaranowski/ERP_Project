#region

using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using ProjectERP.Model.Database;
using System.Linq;
#endregion

namespace ProjectERP.ViewModel
{
    public class CounterpartyModelView : ViewModelBase
    {
        public ObservableCollection<Counterparty> Counterparties { get; } =
            new ObservableCollection<Counterparty>();

        public CounterpartyModelView()
        {
            var db = new ERP_DatabaseContainer();


            //var list = (from cp in db.Counterparty
            //    select cp);

            Console.WriteLine("FF");


        }
    }
}
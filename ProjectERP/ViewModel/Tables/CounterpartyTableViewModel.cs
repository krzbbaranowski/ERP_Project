#region

using System;
using System.Collections.ObjectModel;
using ProjectERP.Interfaces;
using ProjectERP.Model.Database;

#endregion

namespace ProjectERP.ViewModel.Tables
{
    public class CounterpartyTableViewModel : TableViewModel, IContentView
    {
        public CounterpartyTableViewModel() : base(typeof(Counterparty))
        {
            Init();
        }

        private void Init()
        {
            Counterparties.Clear();
            foreach (var item in base.Items)
            {
                Counterparties.Add((Counterparty)item);
            }
        }

        public ObservableCollection<Counterparty> Counterparties { get; protected set; } =
            new ObservableCollection<Counterparty>();

        public bool CanAddItem { get; set; } = true;
        public bool CanDeleteItem { get; set; } = true;
        public bool CanSaveItem { get; set; } = false;

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
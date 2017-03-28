#region

using System;
using ProjectERP.Interfaces;
using ProjectERP.Model.Database;

#endregion

namespace ProjectERP.ViewModel.Tables
{
    public class CounterpartyTableViewModel : TableViewModel, IContentView
    {
        public CounterpartyTableViewModel() : base(typeof(Counterparty))
        {
        }

        public bool CanAddItem { get; set; } = true;
        public bool CanDeleteItem { get; set; } = true;
        public bool CanSaveItem { get; set; } = false;

        public void AddToDatabase()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Windows.Controls;
using ProjectERP.Enums;
using ProjectERP.Interfaces;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;
using ProjectERP.ViewModel.Details;
using ProjectERP.ViewModel.Tables;
using ProjectERP.Views.Tables;

namespace ProjectERP.Factories
{
    public class TabNameFactory
    {
        public static TabName GeTabNameByType(object obj)
        {
            Type objectType = obj.GetType();

            if (objectType == typeof(CounterpartyViewModel))
            {
                return TabName.CounterpartyTab;
            }
            else if(objectType == typeof(CounterpartyTableViewModel))
            {
                return TabName.CounterpartyTabTable;
            }

           return TabName.CounterpartyTab;
        }
    }
}
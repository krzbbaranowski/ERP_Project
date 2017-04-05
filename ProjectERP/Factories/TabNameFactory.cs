using ProjectERP.Enums;
using ProjectERP.ViewModel.Details;
using ProjectERP.ViewModel.Tables;

namespace ProjectERP.Factories
{
    public class TabNameFactory
    {
        public static TabName GetTabNameByType(object obj)
        {
            var objectType = obj.GetType();

            if (objectType == typeof(CounterpartyViewModel))
                return TabName.CounterpartyTab;
            if (objectType == typeof(CounterpartyTableViewModel))
                return TabName.CounterpartyTabTable;

            return TabName.CounterpartyTab;
        }
    }
}
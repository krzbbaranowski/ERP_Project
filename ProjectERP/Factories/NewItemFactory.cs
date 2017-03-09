using System.Windows.Controls;
using ProjectERP.Enums;
using ProjectERP.Interfaces;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;
using ProjectERP.Views.Tables;

namespace ProjectERP.Factories
{
    public class NewItemFactory
    {
        public static MainTabItem CreateClearMainTabItem(TabName tabName, object extra)
        {
            MainTabItem mainTabItem = null;

            switch (tabName)
            {
                case TabName.CounterpartyTabTable:
                    mainTabItem = new MainTabItem
                    {
                        Header = "Kontrahenci",
                        Content = new CounterpartyTableView(),
                        TabType = TabType.Maintab,
                        TabName = TabName.CounterpartyTabTable
                    }; 
                    break;
                    case TabName.CounterpartyTab:
                    if (extra == null)
                    {
                        extra = new Counterparty();
                    }
                    Counterparty counterparty = (Counterparty) extra;
                    mainTabItem = new MainTabItem
                    {
                        Header = $"Kontrahent {counterparty.Name1}",
                        TabType = TabType.Subtab,
                        Extra = counterparty,
                        TabName = TabName.CounterpartyTab
                    };
                    break;
            }

            return mainTabItem;
        }
    }
}
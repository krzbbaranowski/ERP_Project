using ProjectERP.Enums;
using ProjectERP.Model.Database;
using ProjectERP.Model.DataObjects;
using ProjectERP.Model.Enitites;
using ProjectERP.Views.Tables;

namespace ProjectERP.Factories
{
    public class TabItemFactory
    {
        public static MainTabItem CreateClearMainTabItem(TabName tabName, object extra = null)
        {
            MainTabItem mainTabItem = null;

            switch (tabName)
            {
                case TabName.CounterpartyTabTable:
                    mainTabItem = new MainTabItem
                    {
                        Header = "Kontrahenci",
                        Content = new CounterpartyTableView(),
                        TabType = TabType.Single,
                        TabName = TabName.CounterpartyTabTable
                    };
                    break;

                case TabName.CounterpartyTab:
                    if (extra
                        == null)
                        extra = new Counterparty();
                    var counterparty = (Counterparty) extra;
                    mainTabItem = new MainTabItem
                    {
                        Header = $"Kontrahent {counterparty.Name1}",
                        TabType = TabType.Multiple,
                        Extra = counterparty,
                        TabName = TabName.CounterpartyTab
                    };
                    break;
            }

            return mainTabItem;
        }
    }
}
using System.Collections.Generic;
using System.Windows.Controls;

namespace ProjectERP.Model.DataObjects
{
    public class MainTabItem
    {
        public string Header { get; set; }
        public UserControl Content { get; set; }
        public List<UserControl> ContentSubtabs { get; set; }
    }
}
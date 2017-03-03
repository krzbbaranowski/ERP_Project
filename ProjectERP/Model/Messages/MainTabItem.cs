using System.Windows.Controls;
using ProjectERP.Enums;

namespace ProjectERP.Model.Messages
{
    public class MainTabItem
    {
        public string Header { get; set; }
        public UserControl Content { get; set; }
        public TabType TabType { get; set; }
        public object Extra { get; set; }
    }
}
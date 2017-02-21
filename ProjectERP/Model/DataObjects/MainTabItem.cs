using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;

namespace ProjectERP.Model.DataObjects
{
    public class MainTabItem
    {
        public string Header { get; set; }
        public UserControl Content { get; set; }

    }
}
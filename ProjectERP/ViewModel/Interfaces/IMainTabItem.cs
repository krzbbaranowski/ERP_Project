using System.Windows.Controls;

namespace ProjectERP.ViewModel.Interfaces
{
    public interface IMainTabItem
    {
        string Header { get; set; }
        bool IsMultiply { get; set; }
    }
}
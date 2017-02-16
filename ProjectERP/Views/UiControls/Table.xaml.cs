using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProjectERP.Views.UiControls

{
    /// <summary>
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class Table : UserControl
    {
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();

        public Table()
        {
            InitializeComponent();
        }
    }
}
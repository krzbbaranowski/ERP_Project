using System.Windows;
using ProjectERP.Services;

namespace ProjectERP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseAccessService _databaseService;
        private DatabaseAccessServiceClient _databaseAccessServiceGetter;

        public MainWindow()
        {
            InitializeComponent();

            _databaseService = new DatabaseAccessService();
            _databaseAccessServiceGetter = new DatabaseAccessServiceClient();
            
        }
    }
}
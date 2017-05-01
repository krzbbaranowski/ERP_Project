using System.Windows;
using ProjectERP.Services;

namespace ProjectERP
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppInitialize();
        }

        private void AppInitialize()
        {
            AppDictionary.Instance.RegisterDictionary("Dictionary/StringDictionary.xaml", "StringLocs");

        }
    }
}
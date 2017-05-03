using System.Windows;
using System.Windows.Controls;

namespace MaterialControls
{
    /// <summary>
    ///     Interaction logic for IconButton.xaml
    /// </summary>
    public partial class IconButton : UserControl
    {
        public static readonly DependencyProperty TextAProperty =
            DependencyProperty.Register("TextA", typeof(string), typeof(IconButton));

        public IconButton()
        {
            InitializeComponent();
            TextA = "TestText";
        }

        public string TextA
        {
            get => (string) GetValue(TextAProperty);
            set => SetValue(TextAProperty, value);
        }
    }
}
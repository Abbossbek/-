
using System.Windows;

using ПомощникПовара.Windows;

namespace ПомощникПовара
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExspert_Click(object sender, RoutedEventArgs e)
        {
            SimpleArtificialIntelligenceWindow window = new SimpleArtificialIntelligenceWindow();
            window.ShowDialog();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserWindow window = new UserWindow();
            window.ShowDialog();
        }
    }
}

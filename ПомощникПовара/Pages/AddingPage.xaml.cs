using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ПомощникПовара.Model;
using ПомощникПовара.Windows;

namespace ПомощникПовара.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddingPage.xaml
    /// </summary>
    public partial class AddingPage : Page
    {
        public ProductWindow ExtraWindow { get; private set; }

        public AddingPage()
        {
            InitializeComponent();
            lbProducts.ItemsSource = Global.db.Products.ToList();
            lbExtras.ItemsSource = Global.db.Extras.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow();
            productWindow.ShowDialog();
            lbProducts.ItemsSource = Global.db.Products.ToList();
        }

        private void btnAddExtra_Click(object sender, RoutedEventArgs e)
        {
            ExtraWindow extraWindow  = new ExtraWindow();
            extraWindow.ShowDialog();
            lbExtras.ItemsSource = Global.db.Extras.ToList();
        }
    }
}

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
using System.Windows.Shapes;
using ПомощникПовара.Model;

namespace ПомощникПовара.Windows
{
    /// <summary>
    /// Логика взаимодействия для SelectProductWindow.xaml
    /// </summary>
    public partial class SelectProductWindow : Window
    {
        public List<Product> Products { get; private set; }
        public SelectProductWindow()
        {
            InitializeComponent();
            Products = new List<Product>();
            lbProducts.ItemsSource = Global.db.Products.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow();
            productWindow.ShowDialog();
            lbProducts.ItemsSource = Global.db.Products.ToList();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lbProducts.SelectedItems)
            {
                Products.Add((Product)item);
            }
            DialogResult = true;
            Close();
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        Product product;
        public ProductWindow(Product product=null)
        {
            InitializeComponent();
            if (product == null)
            {
                DataContext = this.product = new Product();
            }
            else
            {
                DataContext = this.product = product;
            }
            if (string.IsNullOrWhiteSpace(product?.IconSource))
                piProduct.Visibility = Visibility.Collapsed;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Global.db.Products.AddOrUpdate(product);
            Global.db.SaveChanges();
            Close();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter= "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"};
            openFileDialog.ShowDialog();
            product.IconSource = openFileDialog.FileName;
            try
            {
                img.Source = new BitmapImage(new Uri(product.IconSource));
                if (string.IsNullOrWhiteSpace(product?.IconSource))
                    piProduct.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex) { }
        }
    }
}

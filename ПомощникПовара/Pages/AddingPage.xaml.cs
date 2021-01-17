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
        Meal meal;

        public AddingPage(Meal meal=null)
        {
            InitializeComponent();
            if (meal == null)
            {
                DataContext = this.meal = new Meal();
            }else
            {
                DataContext = this.meal = meal;
                btnAdd.Content = "Изменить";
            }
            if (this.meal.Products == null)
                this.meal.Products = new List<Product>();
            if (this.meal.Extras == null)
                this.meal.Extras = new List<Extra>();
            lbProducts.ItemsSource = this.meal.Products;
            lbExtras.ItemsSource = this.meal.Extras;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Global.db.Meals.AddOrUpdate(meal);
            Global.db.SaveChanges();
            NavigationService.Navigate(new MealsPage());
        }

        private void btnAddExtra_Click(object sender, RoutedEventArgs e)
        {
            SelectExtraWindow extraWindow  = new SelectExtraWindow();
            extraWindow.ShowDialog();
            if (extraWindow.DialogResult == true)
            {
                meal.Extras.AddRange(extraWindow.Extras);
            }
            lbExtras.ItemsSource = meal.Extras;
            lbExtras.Items.Refresh();
        }

        private void btnOpenImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*" };
            openFileDialog.ShowDialog();
            meal.IconSource = openFileDialog.FileName;
            try
            {
                img.Source = new BitmapImage(new Uri(meal.IconSource));
            }
            catch (Exception ex) { }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            SelectProductWindow productWindow = new SelectProductWindow();
            productWindow.ShowDialog();
            if (productWindow.DialogResult == true)
            {
                meal.Products.AddRange(productWindow.Products);
            }
            lbProducts.ItemsSource = meal.Products;
            lbProducts.Items.Refresh();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            lbProducts.ItemsSource = Global.db.Products.ToList();
            lbExtras.ItemsSource = Global.db.Extras.ToList();
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            List<Meal> meals = new List<Meal>();
            foreach(var meal in Global.db.Meals.Include("Products").Include("Extras").ToList())
            {
                bool canCook = true;
                foreach (var product in meal.Products)
                {
                    if (!lbProducts.SelectedItems.Contains(product))
                    {
                        canCook = false;
                    }
                }
                foreach (var extra in meal.Extras)
                {
                    if (!lbExtras.SelectedItems.Contains(extra))
                    {
                        canCook = false;
                    }
                }
                if (canCook)
                {
                    meals.Add(meal);
                }
            }
            FindedMealsWindow findedMealsWindow = new FindedMealsWindow(meals);
            findedMealsWindow.ShowDialog();            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

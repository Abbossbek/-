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

namespace ПомощникПовара.Pages
{
    /// <summary>
    /// Логика взаимодействия для MealsPage.xaml
    /// </summary>
    public partial class MealsPage : Page
    {
        public MealsPage()
        {
            InitializeComponent();
            lbMeals.ItemsSource = Global.db.Meals.Include("Products").Include("Extras").ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddingPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());

        }

        private void MenuItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AddingPage((Meal)lbMeals.SelectedItem));
        }
    }
}

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
    /// Логика взаимодействия для FindedMealsWindow.xaml
    /// </summary>
    public partial class FindedMealsWindow : Window
    {
        public FindedMealsWindow(List<Meal> meals)
        {
            InitializeComponent();
            lbMeals.ItemsSource = meals;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

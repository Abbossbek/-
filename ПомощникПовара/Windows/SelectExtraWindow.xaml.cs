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
    /// Логика взаимодействия для SelectExtraWindow.xaml
    /// </summary>
    public partial class SelectExtraWindow : Window
    {
        public List<Extra> Extras { get; private set; }
        public SelectExtraWindow()
        {
            InitializeComponent();
            Extras = new List<Extra>();
            lbExtras.ItemsSource = Global.db.Extras.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ExtraWindow extraWindow = new ExtraWindow();
            extraWindow.ShowDialog();
            lbExtras.ItemsSource = Global.db.Extras.ToList();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lbExtras.SelectedItems)
            {
                Extras.Add((Extra)item);
            }
            DialogResult = true;
            Close();
        }
    }
}

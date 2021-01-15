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
    /// Логика взаимодействия для ExtraWindow.xaml
    /// </summary>
    public partial class ExtraWindow : Window
    {
        Extra extra;
        public ExtraWindow(Extra extra=null)
        {
            InitializeComponent();
            if (extra == null)
            {
                DataContext = this.extra = new Extra();
            }
            else
            {
                DataContext = this.extra = extra;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Global.db.Extras.AddOrUpdate(extra);
            Global.db.SaveChanges();
            Close();
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ПомощникПовара.DBContext;
using ПомощникПовара.Model;
using ПомощникПовара.Windows;

namespace ПомощникПовара
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        Result result;
        public StartWindow()
        {
            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            Global.db = new DataBaseContext();
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

            base.OnContentRendered(e);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            MainWindow mainForm = new MainWindow();
                mainForm.Closing += Window_Closing;
                mainForm.ShowDialog();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                result = Global.db.Results.Find(1);
            }
            catch
            {
                Global.db.Database.Delete();
                Global.db = new DataBaseContext();
                result = Global.db.Results.Find(1);
            }
        }
    }
}

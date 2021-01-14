﻿using System;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            lbProducts.ItemsSource = new List<Product>() { new Product() { Name = "Olma" }, new Product() { Name = "Nok" } };
            lbAdditional.ItemsSource = new List<Product>() { new Product() { Name = "Olma" } };
        }
    }
}

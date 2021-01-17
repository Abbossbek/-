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
    /// Логика взаимодействия для SimpleArtificialIntelligenceWindow.xaml
    /// </summary>
    public partial class SimpleArtificialIntelligenceWindow : Window
    {
        public SimpleArtificialIntelligenceWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void btnAddAtribut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Global.db.Atributs.Add(new Atribut());
            Refresh();
        }

        private void Refresh()
        {
            dgAtributs.CommitEdit();
            dgAtributs.CommitEdit();
            dgValues.CommitEdit();
            dgValues.CommitEdit();
            Global.db.SaveChanges();
            dgAtributs.ItemsSource = Global.db.Atributs.ToList();
            dgValues.ItemsSource = Global.db.Values.ToList();
            for(int i=0;i<spAtributs.Children.Count;i++)
            {
                ((ComboBox)spAtributs.Children[i]).ItemsSource = Global.db.Atributs.ToList();
                ((ComboBox)spValues.Children[i]).ItemsSource = Global.db.Values.ToList();
            }
            cbAtribut.ItemsSource = Global.db.Atributs.ToList();
            cbValue.ItemsSource= Global.db.Values.ToList();
            lbResults.Items.Clear();
            int count = 1;
            foreach(var item in Global.db.Results.Include("Conditions").ToList())
            {
                string result = $"P{count}: ЕСЛИ ";
                foreach(var pair in item.Conditions)
                {
                    result += pair.Atribut.Name + " = " + pair.Value.Name + " и ";
                }
                result = result.Remove(result.Length - 2) + " ТОГДА " + item.Atribut.Name + " = " + item.Value.Name;
                lbResults.Items.Add(result);
                count++;
            }
        }

        private void btnAddValue_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Global.db.Values.Add(new Value());
            Refresh();
        }

        private void btnAddContition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            spConditions.Children.Add(GetClone<TextBlock>((TextBlock)spConditions.Children[0]));
            ((TextBlock)spConditions.Children[spConditions.Children.Count - 1]).Text = "и";
            spAtributs.Children.Add(GetClone<ComboBox>((ComboBox)spAtributs.Children[0]));
            spEquals.Children.Insert(0, GetClone<TextBlock>((TextBlock)spEquals.Children[0]));
            spValues.Children.Add(GetClone<ComboBox>((ComboBox)spValues.Children[0]));
        }

        private T GetClone<T>(T element) where T : class, new()
        {
                var sourceProperties = typeof(T)
                                        .GetProperties()
                                        .Where(p => p.CanRead && p.CanWrite);
                var newObj = new T();
                foreach (var property in sourceProperties)
                {
                        property.SetValue(newObj, property.GetValue(element, null), null);
                }
                return newObj;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            List<AtributValuePair> atributValuePairs = new List<AtributValuePair>();
            for (int i = 0; i < spAtributs.Children.Count; i++)
            {
                Atribut atribut;
                Value value;
                try
                {
                    atribut = (Atribut)((ComboBox)spAtributs.Children[i]).SelectedItem;
                    value = (Value)((ComboBox)spValues.Children[i]).SelectedItem;
                }catch(Exception ex)
                {
                    MessageBox.Show("Заполните все");
                    return;
                }
                atributValuePairs.Add(new AtributValuePair()
                {
                    Atribut = atribut,
                    Value = value
                });
            }
            if (cbAtribut.SelectedItem != null && cbValue.SelectedItem != null)
                Global.db.Results.AddOrUpdate(new Result()
                {
                    Atribut = (Atribut)cbAtribut.SelectedItem,
                    Value = (Value)cbValue.SelectedItem,
                    Conditions = atributValuePairs
                });
            else
                MessageBox.Show("Заполните все");
            Refresh();
        }
    }
}

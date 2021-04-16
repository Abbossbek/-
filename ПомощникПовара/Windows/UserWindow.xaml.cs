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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            ComboBox cbAtribut = (ComboBox)spAtributs.Children[spAtributs.Children.Count - 1];
            cbAtribut.ItemsSource = Global.db.Atributs.ToList();
            cbAtribut.SelectionChanged += CbAtribut_SelectionChanged; ;
            ((ComboBox)spValues.Children[spValues.Children.Count - 1]).ItemsSource = Global.db.Values.ToList();
        }

        private void CbAtribut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            List<Value> values = new List<Value>();
            foreach (var item in Global.db.Results.Include("Conditions").ToList())
            {
                foreach (var condition in item.Conditions)
                {
                    if (condition.Atribut == comboBox.SelectedItem)
                    {
                        values.Add(condition.Value);
                    }
                }
            }
            ((ComboBox)spValues.Children[spAtributs.Children.IndexOf((ComboBox)sender)]).ItemsSource = values;
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            List<AtributValuePair> atributValuePairs = new List<AtributValuePair>();
            List<Result> results = new List<Result>();
            for (int i = 0; i < spAtributs.Children.Count; i++)
            {
                Atribut atribut;
                Value value;
                try
                {
                    atribut = (Atribut)((ComboBox)spAtributs.Children[i]).SelectedItem;
                    value = (Value)((ComboBox)spValues.Children[i]).SelectedItem;
                }
                catch (Exception ex)
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
            int maxSimilarCount = 0;
            Result nearestResult=null;
            foreach (var result in Global.db.Results.Include("Conditions").ToList())
            {
                bool isResult = true;
                int similarCount = 0;
                foreach (var condition in result.Conditions)
                {
                    if (atributValuePairs.Where(x=>x.Atribut == condition.Atribut && x.Value == condition.Value).Count()==0)
                    {
                        isResult = false;
                        break;
                    }
                    else
                    {
                        similarCount++;
                    }
                }
                if (isResult)
                {
                    results.Add(result);
                }
                if (similarCount > maxSimilarCount)
                {
                    maxSimilarCount = similarCount;
                    nearestResult = result;
                }
            }
            if (results.Count == 0)
            {
                tbResult.Text = "Я не могу вам ничего предложить...  ☹️";
                if (nearestResult != null)
                {
                    tbResult.Text += "\nПожалуйста, выберите следующий факт!";
                    foreach (var condition in nearestResult.Conditions)
                    {
                        if (atributValuePairs.Where(x => x.Atribut == condition.Atribut && x.Value == condition.Value).Count() == 0)
                        {
                            btnAddContition_MouseDown(null, null);
                            foreach (ComboBox child in spAtributs.Children)
                            {
                                if (child.SelectedIndex == -1)
                                {
                                    child.SelectedItem = condition.Atribut;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                tbResult.Text = "Я вам предлагаю: ";
                foreach (var result in results)
                {
                    tbResult.Text += result.Value.Name + ", ";
                }
                tbResult.Text = tbResult.Text.Remove(tbResult.Text.Length - 3);
            }
                //spConditions.Children.RemoveRange(1, spConditions.Children.Count - 1);
                //spAtributs.Children.RemoveRange(1, spAtributs.Children.Count - 1);
                //spEquals.Children.RemoveRange(0, spEquals.Children.Count - 2);
                //spValues.Children.RemoveRange(1, spValues.Children.Count - 1);
        }

        private void btnAddContition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            spConditions.Children.Add(Global.GetClone<TextBlock>((TextBlock)spConditions.Children[0]));
            ((TextBlock)spConditions.Children[spConditions.Children.Count - 1]).Text = "и";
            ComboBox cbAtribut = Global.GetClone<ComboBox>((ComboBox)spAtributs.Children[spAtributs.Children.Count - 1]);
            cbAtribut.ItemsSource = Global.db.Atributs.ToList();
            cbAtribut.SelectedIndex = -1;
            cbAtribut.SelectionChanged += CbAtribut_SelectionChanged;
            spAtributs.Children.Add(cbAtribut);
            spEquals.Children.Insert(0, Global.GetClone<TextBlock>((TextBlock)spEquals.Children[0]));
            ComboBox cbValue = Global.GetClone<ComboBox>((ComboBox)spValues.Children[0]);
            cbValue.SelectedIndex = -1;
            spValues.Children.Add(cbValue);
            ((ComboBox)spAtributs.Children[spAtributs.Children.Count-1]).ItemsSource = Global.db.Atributs.ToList();
            ((ComboBox)spValues.Children[spAtributs.Children.Count - 1]).ItemsSource = Global.db.Values.ToList();
        }
    }
}

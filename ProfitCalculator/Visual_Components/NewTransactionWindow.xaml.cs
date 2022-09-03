using MahApps.Metro.Controls;
using ProfitCalculator.Classes.Model;
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

namespace ProfitCalculator.Visual_Components
{
    /// <summary>
    /// Interaktionslogik für NewTransactionWindow.xaml
    /// </summary>
    public partial class NewTransactionWindow : MetroWindow
    {
        public Transaction Transaction { get => transaction; }
        public List<Categorie> Categories { get => categories; set => categories = value; }

        private Transaction transaction;
        private List<Categorie> categories;

        private bool showMode = false;

        public NewTransactionWindow()
        {
            InitializeComponent();
            dateTimePicker.SelectedDate = DateTime.Now;
        }

        public NewTransactionWindow(Transaction transaction, List<Categorie> categories)
        {
            InitializeComponent();

            this.showMode = true;

            textBoxName.IsEnabled = false;
            textBoxName.Text = transaction.Name;

            textBoxProfit.IsEnabled = false;
            textBoxProfit.Text = transaction.Profit.ToString();

            dateTimePicker.IsEnabled = false;
            dateTimePicker.SelectedDate = transaction.TransactionTime;

            comboBoxCategorie.Items.Add(categories.FirstOrDefault(c => c.ID == transaction.CategorieID));
            comboBoxCategorie.SelectedIndex = 0;
            comboBoxCategorie.IsEnabled = false;

            buttonAdd.Visibility = Visibility.Hidden;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FillCategories();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void FillCategories()
        {
            if (!showMode)
            {
                foreach (Categorie categorie in this.categories)
                {
                    comboBoxCategorie.Items.Add(categorie);
                }
            }
        }

        private void Add()
        {
            string name = textBoxName.Text;
            if (!double.TryParse(textBoxProfit.Text, out double profit)) return;
            Categorie categorie = comboBoxCategorie.SelectionBoxItem as Categorie;
            DateTime dateTime = (DateTime)dateTimePicker.SelectedDate;

            if(name != null  && name != string.Empty && categorie != null && dateTime != null)
            {
                this.transaction = new Transaction(profit, name, dateTime, categorie.ID);
                this.DialogResult = true;
                this.Close();
            }
        }
    }
}

using MahApps.Metro.Controls;
using ProfitCalculator.Classes;
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
using ProfitCalculator.Visual_Components;

namespace ProfitCalculator.Visual_Components
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public Account Account { get => account; set { account = value; ReloadGUI(); } }

        private Account account;

        public delegate void DelOpenCategorieWindow(object sender);
        public event DelOpenCategorieWindow OpenCategorieWindow;

        public delegate void DelOpenNewTransactionWindow(object sender);
        public event DelOpenNewTransactionWindow OpenNewTransactionWindow;

        public delegate void DelShowExistTransactionWindow(object sender, Transaction transaction);
        public event DelShowExistTransactionWindow ShowExistTransactionWindow;

        public MainWindow()
        {
            InitializeComponent();

            Controller controller = new Controller(this);
            comboBox.IsEnabled = false;
        }

        private void Account_TransactionAdded(object sender, Transaction newTransaction)
        {
            AddNewTransaction(newTransaction);
            UpdateValues(this.account);

            if (checkBoxFilter.IsChecked == true)
                checkBoxFilter.IsChecked = false;
        }

        private void ButtonAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            OpenNewTransactionWindow?.Invoke(this);
        }

        private void ButtonCategories_Click(object sender, RoutedEventArgs e)
        {
            OpenCategorieWindow?.Invoke(this);
            FillCategories();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowExistTransactionWindow?.Invoke(this, listBox.SelectedItem as Transaction);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterTransactions(comboBox.SelectedItem as Categorie);
        }

        private void CheckBoxFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            comboBox.IsEnabled = false;
            comboBox.SelectedIndex = -1;
            FilterTransactions(null);
        }

        private void CheckBoxFilter_Checked(object sender, RoutedEventArgs e)
        {
            comboBox.IsEnabled = true;
            comboBox.SelectedIndex = 0;
        }

        public void ReloadGUI()
        {
            this.account.TransactionAdded += Account_TransactionAdded;
            transactionChart.Transactions = this.account.Transactions.ToList();
            UpdateValues(this.account);
            FillCategories();
        }

        private void UpdateValues(Account account)
        {
            labelBankBalance_Value.Content = account.BankBalance + "€";
            totalProfitControl.Value = account.TotalProfit;
            positivProfitControl.Value = account.PositivProfitPercent;
            maxProfitControl.Value = account.MaxProfit;
            maxLossControl.Value = account.MaxLoss;
            profitAverageControl.Value = account.ProfitAverage;
            transactionChart.Transactions = account.Transactions.ToList();

            listBox.Items.Clear();

            foreach (Transaction transaction in account.Transactions)
            {
                AddNewTransaction(transaction);
            }
        }

        private void FilterTransactions(Categorie categorie)
        {
            Account filterdAccount;

            if (categorie != null)
            {
                filterdAccount = new Account(0);

                foreach (Transaction transaction in this.account.Transactions.Where(t => t.CategorieID == categorie.ID))
                {
                    filterdAccount.AddTransaction(transaction);
                }
            }
            else
            {
                filterdAccount = this.account;
            }

            UpdateValues(filterdAccount);
        }

        private void AddNewTransaction(Transaction transaction)
        {
            double value = transaction.Profit;

            listBox.Items.Add(transaction);
        }

        private void FillCategories()
        {
            comboBox.Items.Clear();

            foreach (Categorie categorie in this.account.Categories)
            {
                comboBox.Items.Add(categorie);
            }
        }
    }
}

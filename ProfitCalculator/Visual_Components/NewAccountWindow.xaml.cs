using MahApps.Metro.Controls;
using ProfitCalculator.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaktionslogik für NewAccountWindow.xaml
    /// </summary>
    public partial class NewAccountWindow : MetroWindow
    {
        public Account Account { get => account; }

        private Account account;

        public NewAccountWindow()
        {
            InitializeComponent();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void Create()
        {
            string text = textBoxBalance.Text;

            if(text != null && text != string.Empty)
            {
                if (double.TryParse(text, out double result))
                {
                    this.account = new Account(result);
                    this.DialogResult = true;
                    this.Close();
                }
            }
        }
    }
}

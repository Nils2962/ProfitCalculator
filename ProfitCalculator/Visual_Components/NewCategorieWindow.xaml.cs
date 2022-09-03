using MahApps.Metro.Controls;
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
    /// Interaktionslogik für NewCategorieWindow.xaml
    /// </summary>
    public partial class NewCategorieWindow : MetroWindow
    {
        public string NewCategorieName { get; private set; }

        public NewCategorieWindow()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = textBoxName.Text;

            if(name != null && name != string.Empty)
            {
                this.NewCategorieName = name;
                window.DialogResult = true;
                window.Close();
            }
        }
    }
}

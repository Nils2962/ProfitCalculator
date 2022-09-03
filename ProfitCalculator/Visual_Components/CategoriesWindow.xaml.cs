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
    /// Interaktionslogik für CategoriesForm.xaml
    /// </summary>
    public partial class CategoriesWindow : MetroWindow
    {
        public List<Categorie> Categories { get => categories; set { categories = value; FillList(); } }

        private List<Categorie> categories;

        public CategoriesWindow()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddNewCategorie();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            RemoveCatergorie();
        }

        private void AddNewCategorie()
        {
            NewCategorieWindow newCategorieWindow = new NewCategorieWindow()
            {
                Owner = this
            };

            //05071975
            if((bool)newCategorieWindow.ShowDialog())
            {
                string newName = newCategorieWindow.NewCategorieName;

                Categorie catergorieExist = this.categories.FirstOrDefault(c => c.Name == newName);

                if(catergorieExist == null)
                {
                    Categorie newCategorie = new Categorie(newName);

                    AddCategorie(newCategorie);
                    this.categories.Add(newCategorie);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.Categorie_Exist, Properties.Resources.Warning, MessageBoxButton.OK);
                }
            }
        }

        private void RemoveCatergorie()
        {
            Categorie selectedItem = listBoxCategories.SelectedItem as Categorie;

            if(selectedItem != null)
            {
                this.categories.Remove(selectedItem);
                listBoxCategories.Items.Remove(selectedItem);
            }
        }

        private void FillList()
        {
            listBoxCategories.Items.Clear();

            foreach (Categorie categorie in this.categories)
            {
                AddCategorie(categorie);
            }
        }

        private void AddCategorie(Categorie categorie)
        {
            listBoxCategories.Items.Add(categorie);
        }
    }
}

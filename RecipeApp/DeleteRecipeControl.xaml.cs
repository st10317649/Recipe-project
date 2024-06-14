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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeApp
{
    public partial class DeleteRecipeControl : UserControl
    {
        public DeleteRecipeControl()
        {
            InitializeComponent();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            cmbRecipes.ItemsSource = mainWindow.Recipes;
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)cmbRecipes.SelectedItem;
            if (selectedRecipe != null)
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Recipes.Remove(selectedRecipe);
                MessageBox.Show("Recipe deleted successfully.");
            }
            else
            {
                MessageBox.Show("Please select a recipe to delete.");
            }
        }
    }
}

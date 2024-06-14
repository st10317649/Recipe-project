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
    public partial class DisplayRecipesControl : UserControl
    {
        public DisplayRecipesControl()
        {
            InitializeComponent();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            lstRecipes.ItemsSource = mainWindow.Recipes;
        }

        public void UpdateRecipeList(List<Recipe> filteredRecipes)
        {
            lstRecipes.ItemsSource = filteredRecipes;
        }

        private void ShowDetails_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)lstRecipes.SelectedItem;
            if (selectedRecipe != null)
            {
                RecipeDetailsDialog detailsDialog = new RecipeDetailsDialog(selectedRecipe);
                detailsDialog.ShowDialog();
            }
        }
    }
}

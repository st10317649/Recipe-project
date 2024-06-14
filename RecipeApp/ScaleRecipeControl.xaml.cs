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
    public partial class ScaleRecipeControl : UserControl
    {
        public ScaleRecipeControl()
        {
            InitializeComponent();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            cmbRecipes.ItemsSource = mainWindow.Recipes;
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)cmbRecipes.SelectedItem;
            if (selectedRecipe != null && double.TryParse(txtScaleFactor.Text, out double scaleFactor))
            {
                foreach (var ingredient in selectedRecipe.Ingredients)
                {
                    ingredient.Quantity *= scaleFactor;
                }
                MessageBox.Show("Recipe scaled successfully.");
            }
            else
            {
                MessageBox.Show("Please select a recipe and enter a valid scale factor.");
            }
        }
    }
}

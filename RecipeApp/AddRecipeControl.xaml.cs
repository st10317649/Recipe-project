using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp
{
    public partial class AddRecipeControl : UserControl
    {
        private List<Ingredient> ingredients;

        public AddRecipeControl()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
        }

        private void AddIngredients_Click(object sender, RoutedEventArgs e)
        {
            int numIngredients = int.Parse(txtNumIngredients.Text);
            for (int i = 0; i < numIngredients; i++)
            {
                IngredientDialog ingredientDialog = new IngredientDialog();
                if (ingredientDialog.ShowDialog() == true)
                {
                    ingredients.Add(ingredientDialog.Ingredient);
                }
            }

            RecipeInstructionsDialog instructionsDialog = new RecipeInstructionsDialog();
            if (instructionsDialog.ShowDialog() == true)
            {
                string instructions = instructionsDialog.Instructions;
                Recipe recipe = new Recipe
                {
                    Name = txtRecipeName.Text,
                    Ingredients = ingredients,
                    Instructions = instructions
                };

                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Recipes.Add(recipe);
                MessageBox.Show("Recipe added successfully.");
            }
        }
    }
}

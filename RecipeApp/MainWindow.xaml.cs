using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Linq;
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
    public partial class MainWindow : Window
    {
        public ObservableCollection<Recipe> Recipes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Recipes = new ObservableCollection<Recipe>();
            btnAddRecipe.Click += BtnAddRecipe_Click;
            btnDisplayRecipes.Click += BtnDisplayRecipes_Click;
            btnScaleRecipe.Click += BtnScaleRecipe_Click;
            btnDeleteRecipe.Click += BtnDeleteRecipe_Click;
            cmbFilterFoodGroup.SelectedIndex = 0; // Set default selection to "Any"
        }

        private void BtnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            contentArea.Content = new AddRecipeControl();
        }

        private void BtnDisplayRecipes_Click(object sender, RoutedEventArgs e)
        {
            var displayControl = new DisplayRecipesControl();
            contentArea.Content = displayControl;
            ApplyFilters(displayControl); // Apply filters to the display control
        }

        private void BtnScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            contentArea.Content = new ScaleRecipeControl();
        }

        private void BtnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            contentArea.Content = new DeleteRecipeControl();
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            if (contentArea.Content is DisplayRecipesControl displayControl)
            {
                ApplyFilters(displayControl);
            }
        }

        private void ApplyFilters(DisplayRecipesControl displayControl)
        {
            string ingredientFilter = txtFilterIngredient.Text.ToLower();
            string foodGroupFilter = ((ComboBoxItem)cmbFilterFoodGroup.SelectedItem).Content.ToString();
            int.TryParse(txtFilterMaxCalories.Text, out int maxCaloriesFilter);

            var filteredRecipes = Recipes.Where(recipe =>
                (string.IsNullOrEmpty(ingredientFilter) || recipe.Ingredients.Any(i => i.Name.ToLower().Contains(ingredientFilter))) &&
                (foodGroupFilter == "Any" || recipe.Ingredients.Any(i => i.FoodGroup == foodGroupFilter)) &&
                (maxCaloriesFilter == 0 || recipe.CalculateTotalCalories() <= maxCaloriesFilter)
            ).ToList();

            displayControl.UpdateRecipeList(filteredRecipes);
        }
    }
}
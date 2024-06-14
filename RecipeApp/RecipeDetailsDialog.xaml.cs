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

namespace RecipeApp
{
    public partial class RecipeDetailsDialog : Window
    {
        public RecipeDetailsDialog(Recipe recipe)
        {
            InitializeComponent();
            lstIngredients.ItemsSource = recipe.Ingredients;
            txtInstructions.Text = recipe.Instructions;
        }
    }
}

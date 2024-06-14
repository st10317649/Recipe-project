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
    public partial class IngredientDialog : Window
    {
        public Ingredient Ingredient { get; private set; }

        public IngredientDialog()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Ingredient = new Ingredient
            {
                Name = txtName.Text,
                Quantity = double.Parse(txtQuantity.Text),
                UnitOfMeasurement = txtUnit.Text,
                Calories = int.Parse(txtCalories.Text),
                FoodGroup = txtFoodGroup.Text
            };

            DialogResult = true;
        }
    }
}

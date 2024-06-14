using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{

    // Class representing an ingredient in a recipe
    public class Ingredient
    {
        // Properties of an ingredient
        public string Name { get; set; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public string UnitOfMeasurement { get; set; } // Unit of measurement for the ingredient
        public int Calories { get; set; } // Calories per unit of the ingredient
        public string FoodGroup { get; set; } // Food group to which the ingredient belongs
    }
}

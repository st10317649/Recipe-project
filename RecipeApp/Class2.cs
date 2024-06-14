using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }

        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories * Convert.ToInt32(ingredient.Quantity);
            }
            return totalCalories;
        }
    }
}

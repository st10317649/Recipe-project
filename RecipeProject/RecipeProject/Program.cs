using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject
{
    // Class representing an ingredient in a recipe
    class Ingredient
    {
        // Properties of an ingredient
        public string Name { get; set; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public string UnitOfMeasurement { get; set; } // Unit of measurement for the ingredient
        public int Calories { get; set; } // Calories per unit of the ingredient
        public string FoodGroup { get; set; } // Food group to which the ingredient belongs
    }

    // Class representing a recipe
    class Recipe
    {
        // Properties of a recipe
        public string Name { get; set; } // Name of the recipe
        public List<Ingredient> Ingredients { get; set; } // List of ingredients in the recipe

        // Constructor to initialize a recipe object
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }

        // Method to calculate the total calories of the recipe
        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories * Convert.ToInt32(ingredient.Quantity); // Calculate total calories based on quantity of each ingredient
            }
            return totalCalories;
        }
    }

    class Program
    {
        static List<Recipe> recipes = new List<Recipe>(); // List to store all recipes
        static double scaleFactor; // Declare scaleFactor at class level

        static void Main(string[] args)
        {
            while (true)
            {
                // Display menu options
                Console.WriteLine("Choose an option:\n" +
                                  "1) Enter details for a recipe\n" +
                                  "2) Display All Recipes\n" +
                                  "3) Scale Recipe\n" +
                                  "4) Delete Recipe\n" +
                                  "5) Exit");

                // Read user's choice
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                // Switch based on user's choice
                switch (choice)
                {
                    case 1:
                        AddRecipe(); // Call method to add a new recipe
                        break;
                    case 2:
                        DisplayAllRecipes(); // Call method to display all recipes
                        break;
                    case 3:
                        ScaleRecipe(); // Call method to scale a recipe
                        break;
                    case 4:
                        DeleteRecipe(); // Call method to delete a recipe
                        break;
                    case 5:
                        Console.WriteLine("Exiting program"); // Exit the program
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice"); // Display message for invalid choice
                        break;
                }
            }
        }

        // Method to add a new recipe
        static void AddRecipe()
        {
            Recipe recipe = new Recipe(); // Create a new recipe object

            // Prompt user to enter recipe details
            Console.WriteLine("Enter the name of the recipe:");
            recipe.Name = Console.ReadLine();

            Console.WriteLine("Enter the number of ingredients for the recipe:");
            int numberOfIngredients = Convert.ToInt32(Console.ReadLine());

            // Loop to gather details of each ingredient
            for (int i = 0; i < numberOfIngredients; i++)
            {
                Ingredient ingredient = new Ingredient(); // Create a new ingredient object

                // Prompt user to enter details of each ingredient
                Console.WriteLine($"Enter name of ingredient {i + 1}:");
                ingredient.Name = Console.ReadLine();

                Console.WriteLine($"Enter quantity of {ingredient.Name}:");
                ingredient.Quantity = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"Enter unit of measurement for {ingredient.Name}:");
                ingredient.UnitOfMeasurement = Console.ReadLine();

                Console.WriteLine($"Enter number of calories for {ingredient.Name}:");
                ingredient.Calories = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Enter food group for {ingredient.Name}:");
                ingredient.FoodGroup = Console.ReadLine();

                // Add the ingredient to the recipe
                recipe.Ingredients.Add(ingredient);
            }

            // Add the recipe to the list of recipes
            recipes.Add(recipe);
            Console.WriteLine("Recipe recorded\n");
        }

        // Method to display all recipes
        static void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes recorded\n");
                return;
            }

            // Display all recipes
            Console.WriteLine("Recipes:");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine($"- {recipe.Name}");
            }

            // Prompt user to select a recipe to display
            Console.WriteLine("\nEnter the name of the recipe you want to display:");
            string recipeName = Console.ReadLine();

            // Find the selected recipe and display it
            var selectedRecipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (selectedRecipe != null)
            {
                DisplayRecipe(selectedRecipe);
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to display a recipe
        static void DisplayRecipe(Recipe recipe)
        {
            // Display recipe name
            Console.WriteLine($"Recipe: {recipe.Name}");
            Console.WriteLine("Ingredients:");

            // Display each ingredient with details
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.UnitOfMeasurement}");
                Console.WriteLine($"  Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}");
            }

            // Calculate and display total calories
            Console.WriteLine($"Total Calories: {recipe.CalculateTotalCalories()}");

            // Check if total calories exceed 300 and notify the user using a delegate
            if (recipe.CalculateTotalCalories() > 300)
            {
                NotifyUserExceedsCalories(recipe.Name);
            }
        }

        // Delegate to notify the user if the total calories of a recipe exceed 300
        delegate void NotifyExceedsCalories(string recipeName);

        // Method to notify the user if the total calories of a recipe exceed 300
        static void NotifyUserExceedsCalories(string recipeName)
        {
            Console.WriteLine($"WARNING: The total calories for the recipe '{recipeName}' exceed 300!");
        }

        // Method to scale a recipe
        static void ScaleRecipe()
        {
            Console.WriteLine("Enter the name of the recipe you want to scale:");
            string recipeName = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (recipe != null)
            {
                Console.WriteLine("Choose an option from 1 to 3");
                Console.WriteLine("1) Scale by 0.5 (half)\n2) Scale by 2 (double)\n3) Scale by 3 (triple)");
                int factor = Convert.ToInt32(Console.ReadLine());

                switch (factor)
                {
                    case 1:
                        scaleFactor = 0.5; // Set scaleFactor for half scale
                        ScaleRecipeByFactor(recipe);
                        break;
                    case 2:
                        scaleFactor = 2; // Set scaleFactor for double scale
                        ScaleRecipeByFactor(recipe);
                        break;
                    case 3:
                        scaleFactor = 3; // Set scaleFactor for triple scale
                        ScaleRecipeByFactor(recipe);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                // Prompt user to reset quantities to their original values
                Console.WriteLine("Do you want to reset quantities to their original values? (yes/no)");
                string resetChoice = Console.ReadLine().ToLower();
                if (resetChoice == "yes")
                {
                    ResetQuantityToOriginalValues(recipe);
                }
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to scale a recipe by a factor
        static void ScaleRecipeByFactor(Recipe recipe)
        {
            // Scale the quantity of each ingredient
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Quantity *= scaleFactor;
            }
            Console.WriteLine("The recipe quantities have been scaled");
        }

        // Method to reset quantities to their original values
        static void ResetQuantityToOriginalValues(Recipe recipe)
        {
            // Reset quantities of all ingredients to their original values
            foreach (var ingredient in recipe.Ingredients)
            {
                // Resetting to original values would depend on how you've stored original values.
                // If original values are stored in some separate property, use them to reset.
                // For this demonstration, let's assume original values are stored in the Quantity property itself.
                // You would need to modify this according to your actual implementation.
                // For example, if you have a separate list to store original quantities, you would iterate through that list to reset.
                ingredient.Quantity /= scaleFactor;
            }
            Console.WriteLine("Quantities have been reset to their original values");
        }

        // Method to delete a recipe
        static void DeleteRecipe()
        {
            // Prompt user to enter the name of the recipe to delete
            Console.WriteLine("Enter the name of the recipe you want to delete:");
            string recipeName = Console.ReadLine();

            // Find the recipe and delete it
            var recipe = recipes.FirstOrDefault(r => r.Name == recipeName);
            if (recipe != null)
            {
                recipes.Remove(recipe);
                Console.WriteLine("Recipe deleted");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }
    }
}

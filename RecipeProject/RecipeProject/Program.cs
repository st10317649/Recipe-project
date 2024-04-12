using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RecipeProject
{
     class Program
    {
        // Lists to store recipe data
        static List<string> ingredientName = new List<string>();
        static List<string> unitOfMeasurement = new List<string>();
        static List<string> stepsDescription = new List<string>();
        static List<string> ingredientQuantity = new List<string>();
        static List<string> copyOfQuantity;
        static void Main(string[] args)
        {
            // Display welcome message and initialize variables
            Console.WriteLine("Welcome to Create A Recipe");
            Console.WriteLine();
            int numberOfIngredients = 0;
            int steps = 0;
            string recipeName = "";
            double scaleFactor = 0.0;
            int choice = 0;
            int detailsCount = 0;
            int clearCount = 0;

            // Main program loop
            while (true)
            {
                // Display menu options
                Console.WriteLine("Choose an option:\n" +
                                  "1) Enter details for a recipe\n" +
                                  "2) Display Recipe\n" +
                                  "3) Scale Recipe\n" +
                                  "4) Reset Quantity\n" +
                                  "5) Delete Recipe\n" +
                                  "6) Exit");

                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                // Switch based on user's choice
                switch (choice)
                {
                    case 1:
                        // Gather recipe details
                        recipeName = RecipeName();
                        Console.WriteLine();
                        numberOfIngredients = NumberOfIngredients();
                        Console.WriteLine();
                        IngredientName(numberOfIngredients);
                        Console.WriteLine();
                        IngredientQuantity(numberOfIngredients);
                        Console.WriteLine();
                        UnitOfMeasurement(numberOfIngredients);
                        Console.WriteLine();
                        steps = NumberOfSteps();
                        Console.WriteLine();
                        StepsDescription(steps);
                        Console.WriteLine();
                        Console.WriteLine("Recipe recorded");
                        Console.WriteLine();
                        ++detailsCount;
                        break;
                    case 2:
                        // Display the created recipe
                        if (detailsCount > 0 && clearCount == 0)
                            DisplayRecipe(recipeName);
                        else
                            Console.WriteLine("Recipe cleared or not recorded");
                        
                        break;
                    case 3:
                        // Scale the recipe
                        if (detailsCount > 0)
                        {
                            scaleFactor = FactorOfScale();
                            Console.WriteLine();
                            ScaleRecipe(scaleFactor);
                            Console.WriteLine("The recipe quantities have been scaled");
                        }
                        else
                            Console.WriteLine("recipe not recorded or has been cleared");
                        Console.WriteLine();
                        break;
                    case 4:
                        // Reset quantities to original values
                        if (detailsCount > 0)
                        {
                            ResetQuantityToOriginalValue();
                            Console.WriteLine("Quantity has been reseted to the original values");
                        }
                        else
                            Console.WriteLine("Recipe not recorded or has been cleared");
                        break;
                    case 5:
                        // Delete all recipe data
                        if (detailsCount > 0 && clearCount == 0)
                        {
                            ClearAllData();
                            Console.WriteLine("Recipe cleared");
                        }
                        else
                            Console.WriteLine("Record not recorded or has been cleared");
                        ++clearCount;
                      
                        break;
                  
                    case 6:
                        // Exit the program
                        Console.WriteLine("Exiting program");
                        Environment.Exit(0);
                        break;
                    default:
                        // Invalid choice
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        // Method to gather recipe name
        public static string RecipeName() //1
        {
            Console.WriteLine("Enter the name of your recipe");
            string recipeName = Console.ReadLine();
            return recipeName;
        }

        //Collects the details of a recipe
        public static void RecipeDetails(int numberOfIngredients , int steps)
        {
            RecipeName();
            NumberOfIngredients();
            IngredientName(numberOfIngredients);
            UnitOfMeasurement(numberOfIngredients);
            NumberOfSteps();
            StepsDescription(steps);

        }
        // Method to gather the number of ingredients
        public static int NumberOfIngredients() //2
        {
            Console.WriteLine("Enter the number of ingredients for your recipe");
            int numberOfIngredients = Convert.ToInt32(Console.ReadLine());
            return numberOfIngredients;
        }

        // Method to gather ingredient names
        public static string IngredientName(int numberOfIngredients) //3
        {
            string ingredient = " ";
            for (int i = 0; i < numberOfIngredients; ++i)
            {
                Console.WriteLine($"Enter ingredient {i + 1}");
                ingredient = Console.ReadLine();
                ingredientName.Add(ingredient);
            }
            return ingredient;
        }

        // Method to gather ingredient quantities and units of measurement
        public static void UnitOfMeasurement(int numberOfIngredients) //4
        {
            string measurement = "";
            for (int i = 0; i < numberOfIngredients; ++i)
            {
                Console.WriteLine($"Enter unit of measurement for the {ingredientName[i]}");
                  measurement = Console.ReadLine();
                unitOfMeasurement.Add(measurement);
            }

        }

        public static void IngredientQuantity(int numberOfIngredients) //4
        {
            string quantity = "";
            for (int i = 0; i < numberOfIngredients; ++i)
            {
                Console.WriteLine($"Enter quantity for the {ingredientName[i]}");
                Console.WriteLine("Enter digits only");
                quantity = Console.ReadLine();
                ingredientQuantity.Add(quantity);
            }

            copyOfQuantity = new List<string>(ingredientQuantity);
        }

        // Method to gather the number of steps
        public static int NumberOfSteps() //6
        {
            Console.WriteLine("Enter the number of steps that should be taken in the recipe");
            int steps = Convert.ToInt32(Console.ReadLine());
            return steps;
        }

        // Method to gather step descriptions
        public static void StepsDescription(int steps) //7
        {
            string description = " ";
            for (int i = 0; i < steps; ++i)
            {
                Console.WriteLine($"Enter direction {i + 1}");
                description = Console.ReadLine();
                stepsDescription.Add(description);
            }
        }

        // Method to choose scaling factor
        public static double FactorOfScale() //8
        {
            int factor = 0;
            Console.WriteLine("Choose an option from 1 to 3");
            Console.WriteLine("1) Scale by 0.5 (half)\n2) Scale by 2 (double)\n3) Scale by 3 (triple)");
            factor = Convert.ToInt32(Console.ReadLine());

            if (factor == 1)
                return 0.5;
            else
                if (factor == 2)
                return 2;
            else
                if (factor == 3)
                return 3;
            else
                return 0;

        }

        // Method to scale the recipe
        public static void ScaleRecipe(double scaleFactor)
        {
            for (int i = 0; i < unitOfMeasurement.Count(); ++i)
            {

                // Extract digits and fractions using regular expression
                MatchCollection matches = Regex.Matches(ingredientQuantity[i], @"\d+/\d+|\d+");

                // Keep track of the current index within the input string
                int currentIndex = 0;

                // Offset to keep track of the difference between original and modified string lengths
                int offset = 0;

                foreach (Match match in matches)
                {
                    double value;
                    if (match.Value.Contains("/"))
                    {
                        // If the match contains a fraction, evaluate it and multiply
                        string[] parts = match.Value.Split('/');
                        double numerator = double.Parse(parts[0]);
                        double denominator = double.Parse(parts[1]);
                        value = numerator / denominator;
                    }
                    else
                    {
                        // If it's a regular number, just parse it
                        value = double.Parse(match.Value);
                    }

                    // Multiply the value
                    double multipliedValue = value * scaleFactor; // Multiplying by the scale factor 

                    // Calculate the index for replacing the number in the input string
                    int replaceIndex = match.Index + offset;

                    // Replace the number with the multiplied value in the input string
                    ingredientQuantity[i] = ingredientQuantity[i].Substring(0, replaceIndex) + multipliedValue.ToString() + ingredientQuantity[i].Substring(replaceIndex + match.Length);

                    // Update the offset based on the difference in length between original and modified strings
                    offset += multipliedValue.ToString().Length - match.Length;
                }            
        }
        

    }

        // Method to display the recipe
        public static void DisplayRecipe(string recipeName)
        {
            Console.WriteLine(recipeName);
            Console.WriteLine();
            Console.WriteLine("Ingredients:");
            Console.WriteLine();
            for (int i = 0; i < ingredientQuantity.Count(); ++i)
            {
                Console.WriteLine($"{ingredientQuantity[i]} {unitOfMeasurement[i]}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Directions:");
            Console.WriteLine();

            for(int i = 0; i < stepsDescription.Count(); ++i)
            {
                Console.WriteLine(stepsDescription[i]);
                Console.WriteLine();
            }
        }

        //resets the quantity to its original value
        public static void ResetQuantityToOriginalValue()
        {
            ingredientQuantity.Clear();
            ingredientQuantity.AddRange(copyOfQuantity);

        }

      

        //clears the recorded recipe from the system
        public static void ClearAllData()
        {
            ingredientName.Clear();
            unitOfMeasurement.Clear();
            ingredientQuantity.Clear();
            stepsDescription.Clear();
        }

    }
}

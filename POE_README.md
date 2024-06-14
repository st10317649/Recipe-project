# Recipe-project
RecipeProject is a console application written in C# that allows users to create, display, scale, reset, and delete recipes. It provides an interactive interface for users to input recipe details such as ingredients, quantities, units of measurement, steps, and more.

## Getting Started

To run the application, ensure you have the .NET SDK installed on your system. You can download it from the official [.NET website](https://dotnet.microsoft.com/download).

### Installation

1. Clone or download the repository to your local machine.
2. Open the solution file (`RecipeProject.sln`) in Visual Studio or your preferred C# IDE.
3. Build the solution to ensure all dependencies are resolved.

### Usage

1. Run the application.
2. Choose an option from the menu:
   - **Enter details for a recipe**: Input the recipe details such as name, ingredients, quantities, units of measurement, steps, etc.
   - **Display Recipe**: View the created recipe.
   - **Scale Recipe**: Scale the quantities of ingredients by a factor of 0.5 (half), 2 (double), or 3 (triple).
   - **Reset Quantity**: Reset the quantities of ingredients to their original values.
   - **Delete Recipe**: Clear all recipe data from the system.
   - **Exit**: Terminate the program.

## Features

- **Interactive Menu**: Users can choose from various options using a menu-driven interface.
- **Recipe Creation**: Input recipe details including name, ingredients, quantities, units of measurement, and steps.
- **Recipe Display**: View the created recipe including ingredients and directions.
- **Recipe Scaling**: Scale the quantities of ingredients by a specified factor.
- **Quantity Reset**: Reset ingredient quantities to their original values.
- **Recipe Deletion**: Clear all recipe data from the system.
- **Input Validation**: Ensure user inputs are validated for correctness and completeness.

## Contributing

Contributions are welcome! If you'd like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/improvement`)
3. Make your changes and commit them (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature/improvement`)
5. Create a new Pull Request.

POE
Recipe Project with WPF UI
This Recipe Project is a C# WPF application that allows users to create, view, scale, and delete recipes. Each recipe can contain multiple ingredients, and the application also calculates the total calories of each recipe. Additionally, recipes can be scaled, and users can reset the scaled recipes to their original values.

Features
Add a new recipe with ingredients and instructions
Display all recipes
Display a specific recipe with its details
Scale a recipe by a factor (0.5, 2, or 3)
Reset a scaled recipe to its original values
Delete a recipe
Filter and search for recipes
Warn the user if the total calories of a recipe exceed 300
Getting Started
Prerequisites
.NET Core SDK installed on your machine.
Visual Studio 2019 or later
Installing
Clone the repository:
git clone https://github.com/yourusername/recipe-project-wpf.git
Open the project in Visual Studio:

Open Visual Studio.
Select File > Open > Project/Solution.
Navigate to the directory where you cloned the repository and select the .sln file.
Build the project:

In Visual Studio, select Build > Build Solution.
Run the project:

In Visual Studio, select Debug > Start Debugging or press F5.
Usage
When you run the application, you will see a user interface with buttons for different actions:

Adding a Recipe
Click the "Add Recipe" button.
Enter the name of the recipe.
Enter the number of ingredients.
For each ingredient, enter:
Name
Quantity
Unit of measurement
Number of calories
Food group
Enter the instructions for the recipe.
Click "Save" to add the recipe.
Displaying All Recipes
Click the "Display Recipes" button.
A list of all recipes will be displayed.
Select a recipe from the list to view its details.
Scaling a Recipe
Select a recipe from the list.
Click the "Scale Recipe" button.
Choose a scaling factor (0.5, 2, or 3).
The recipe quantities will be scaled accordingly.
Optionally, click "Reset" to revert to the original quantities.
Resetting a Recipe to Original Values
After scaling a recipe, click the "Reset" button to revert to the original quantities.
Deleting a Recipe
Select a recipe from the list.
Click the "Delete Recipe" button.
Confirm the deletion.
Filtering and Searching Recipes
Use the search bar to filter recipes by name.
Enter the keyword to search and the list will be filtered in real-time.
Example
Adding a Recipe
Click "Add Recipe".
Fill in the details:
Recipe Name: Pancakes
Number of Ingredients: 3
Ingredients:
Name: Flour, Quantity: 2, Unit: cups, Calories: 100, Food Group: Grains
Name: Milk, Quantity: 1, Unit: cup, Calories: 150, Food Group: Dairy
Name: Egg, Quantity: 1, Unit: unit, Calories: 70, Food Group: Protein
Instructions: Mix ingredients and cook on a griddle.
Click "Save".
Displaying a Recipe
Click "Display Recipes".
Select "Pancakes" from the list.
The details of the recipe will be shown, including a warning if the total calories exceed 300.
Scaling a Recipe
Select "Pancakes" from the list.
Click "Scale Recipe".
Choose a scaling factor (e.g., 2 for double).
The quantities of the ingredients will be updated.
To reset, click "Reset".
Deleting a Recipe
Select "Pancakes" from the list.
Click "Delete Recipe".
Confirm the deletion.
Filtering and Searching Recipes
Use the search bar at the top of the recipe list.
Enter a keyword, such as "Pancakes", and the list will update to show only matching recipes.
Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes.

License
This project is licensed under the MIT License.

Contact
Tumelo Neo Mahlaela - st10317649@rcconnect.edu.za

Project Link: https://github.com/st10317649/Recipe-project
Changes made: 
The Recipe Project transitioned from a console application to a WPF UI to enhance user experience and visual appeal. Originally text-based, the console app interacted through command-line prompts and outputs. In contrast, the WPF UI utilizes XAML for layout and styling, offering buttons, lists, and forms for intuitive interaction. Core functionalities—adding, displaying, scaling, and deleting recipes—were retained in C#, adapted to event-driven WPF. This shift allows for a more engaging interface with customizable themes and responsive design, accommodating user preferences and enhancing usability. Overall, the move to WPF facilitates a modern, graphical approach while maintaining efficient recipe management capabilities.







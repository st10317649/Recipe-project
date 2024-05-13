namespace RecipeProject.Tests
{
    [TestFixture]
    public class RecipeTests
    {
        [Test]
        public void CalculateTotalCalories_WithIngredients_ReturnsCorrectTotalCalories()
        {
            // Arrange
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Name = "Ingredient1", Quantity = 2, Calories = 100 });
            recipe.Ingredients.Add(new Ingredient { Name = "Ingredient2", Quantity = 3, Calories = 50 });

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(2 * 100 + 3 * 50, totalCalories);
        }

        [Test]
        public void CalculateTotalCalories_EmptyIngredients_ReturnsZero()
        {
            // Arrange
            Recipe recipe = new Recipe();

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(0, totalCalories);
        }
    }
}
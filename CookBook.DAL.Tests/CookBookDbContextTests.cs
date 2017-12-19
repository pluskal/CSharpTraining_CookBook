using System;
using System.Linq;
using CookBook.DAL.Entities;
using NUnit.Framework;

namespace CookBook.DAL.Tests
{
    [TestFixture]
    public class CookBookDbContextTests : IDisposable
    {
        public CookBookDbContextTests()
        {
            this.DbContext = new CookBookDbContext();
        }

        public CookBookDbContext DbContext { get; set; }

        [Test]
        public void _GetAllRecipes_Any()
        {
            Assert.IsNotEmpty(this.DbContext.Recipes.ToArray());
        }

        [Test]
        public void AddIngredienceTest()
        {
            var ingredient = new IngredientEntity
            {
                Name = "Ingredient name",
                Description = "Ingredient description"
            };

            this.DbContext.Ingredients.Add(ingredient);
            this.DbContext.SaveChanges();

            var ingredientEntity = this.DbContext.Ingredients.FirstOrDefault();

            Assert.NotNull(ingredientEntity);
            Assert.AreEqual(ingredient.Name,ingredientEntity.Name);
            Assert.AreEqual(ingredient.Description,ingredientEntity.Description);
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}

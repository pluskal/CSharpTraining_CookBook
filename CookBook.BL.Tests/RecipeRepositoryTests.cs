using CookBook.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BL.Models;
using NUnit.Framework;

namespace CookBook.BL.Tests
{
    [TestFixture]
    public class RecipeRepositoryTests
    {
        private RecipeRepository _recipeRepository;

        [OneTimeSetUp]
        public void SetUp()
        {
            _recipeRepository = new RecipeRepository(new RecipeMapper());
            _recipeRepository.ClearDatabase();
        }
        [TearDown]
        public void TearDown()
        {
            _recipeRepository.ClearDatabase();
        }

        [Test]
        public void GetAllTest()
        {
            var recipes = _recipeRepository.GetAll();
            Assert.IsEmpty(recipes);
        }

        [Test]
        public void InsertRecipeTest()
        {
            var recipe = CreateRecipeDetailModel();
            _recipeRepository.InsertRecipe(recipe);

            var recipeFromRepository = this._recipeRepository.GetAll().FirstOrDefault(r => r.Name == recipe.Name);

            Assert.IsNotNull(recipeFromRepository);
            Assert.AreEqual(recipeFromRepository.Name,recipe.Name);
            Assert.AreEqual(recipeFromRepository.Duration,recipe.Duration);
            Assert.AreEqual(recipeFromRepository.Type,recipe.Type);
        }

        [Test]
        public void InsertRecipeDetailModelTest()
        {
            var recipe = CreateRecipeDetailModel();
            _recipeRepository.InsertRecipe(recipe);

            GetAssertRecipeDetailModel(recipe);
        }

        [Test]
        public void InsertTwoRecipeDetailModelsTest()
        {
            var recipe1 = CreateRecipeDetailModel();
            _recipeRepository.InsertRecipe(recipe1);
            var recipe2 = CreateRecipeDetailModel();
            _recipeRepository.InsertRecipe(recipe2);

            GetAssertRecipeDetailModel(recipe1);
            GetAssertRecipeDetailModel(recipe2);
        }

        private void GetAssertRecipeDetailModel(RecipeDetailModel recipe)
        {
            var detailModel = this._recipeRepository.GetById(recipe.Id);

            Assert.IsNotNull(detailModel);
            Assert.AreEqual(detailModel, recipe);
        }


        private static RecipeDetailModel CreateRecipeDetailModel()
        {
            var recipe = new RecipeDetailModel()
            {
                Name = "RecipeName",
                Description = "RecipeDescription",
                Duration = new TimeSpan(0, 0, 1),
                Type = FoodType.MainCourse,
                Ingredients = new List<IngredientModel>()
                {
                    new IngredientModel()
                    {
                        Name = "Ingredient1Name",
                        Description = "Ingredient1Description",
                        Unit = Unit.Kg,
                        Amount = 3.14
                    },
                    new IngredientModel()
                    {
                        Name = "Ingredient2Name",
                        Description = "Ingredient2Description",
                        Unit = Unit.Kg,
                        Amount = 3.14
                    }
                }
            };
            return recipe;
        }
    }
}
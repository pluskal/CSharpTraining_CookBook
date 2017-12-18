using System;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using FoodType = CookBook.BL.Models.FoodType;
using Unit = CookBook.DAL.Entities.Unit;

namespace CookBook.BL
{
    public class RecipeMapper
    {
        public RecipeListModel Map(RecipeEntity recipeEntity)
        {
            return new RecipeListModel
            {
                Id = recipeEntity.Id,
                Name = recipeEntity.Name,
                Type = (FoodType) recipeEntity.Type,
                Duration = recipeEntity.Duration
            };
        }

        public RecipeDetailModel MapDetailModel(RecipeEntity recipeEntity)
        {
            return new RecipeDetailModel()
            {
                Id = recipeEntity.Id,
                Name = recipeEntity.Name,
                Description = recipeEntity.Description,
                Type = (FoodType)recipeEntity.Type,
                Duration = recipeEntity.Duration,
                Ingredients = recipeEntity.Ingredients.Select(ia=>new IngredientModel()
                {
                    Name = ia.Ingredient.Name,
                    Description = ia.Ingredient.Description,
                    Amount = ia.Amount,
                    Unit = (Models.Unit) ia.Unit
                }).ToList()
            };
        }

        internal RecipeEntity Map(RecipeDetailModel recipeDetailModel)
        {
            var recipeEntity= new RecipeEntity
            {
                Id = recipeDetailModel.Id,
                Name = recipeDetailModel.Name,
                Description = recipeDetailModel.Description,
                Type = (DAL.Entities.FoodType) recipeDetailModel.Type,
                Duration = recipeDetailModel.Duration,
            };

            foreach (var ingredientModel in recipeDetailModel.Ingredients)
            {
                var ingredientAmount = new IngredientAmountEntity
                {
                    Amount = ingredientModel.Amount,
                    Unit = (Unit) ingredientModel.Unit
                };
                var ingredient = new IngredientEntity
                {
                    Name = ingredientModel.Name,
                    Description = ingredientModel.Description
                };
                ingredientAmount.Ingredient = ingredient;
                recipeEntity.Ingredients.Add(ingredientAmount);
            }
            return recipeEntity;
        }
    }
}
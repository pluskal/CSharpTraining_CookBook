using System;
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

        internal RecipeEntity Map(RecipDetailModel recipDetailModel)
        {
            var recipeEntity= new RecipeEntity
            {
                Id = recipDetailModel.Id,
                Name = recipDetailModel.Name,
                Description = recipDetailModel.Description,
                Type = (DAL.Entities.FoodType) recipDetailModel.Type,
                Duration = recipDetailModel.Duration
            };
            foreach (var ingredientModel in recipDetailModel.Ingredients)
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
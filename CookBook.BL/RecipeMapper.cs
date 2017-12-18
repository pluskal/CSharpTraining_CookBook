using System;
using CookBook.BL.Models;
using CookBook.DAL.Entities;

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
                Type = recipeEntity.Type,
                Duration = recipeEntity.Duration
            };
        }
    }
}
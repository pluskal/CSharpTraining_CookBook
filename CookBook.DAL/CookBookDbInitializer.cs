using System;
using System.Collections.Generic;
using System.Data.Entity;
using CookBook.DAL.Entities;

namespace CookBook.DAL
{
    internal class CookBookDbInitializer : DropCreateDatabaseIfModelChanges<CookBookDbContext>
    {
        protected override void Seed(CookBookDbContext context)
        {
            var recipe = new RecipeEntity
            {
                Name = "RecipeName",
                Description = "RecipeDescription",
                Duration = new TimeSpan(0, 0, 1),
                Type = FoodType.MainCourse,
                Ingredients = new List<IngredientAmountEntity>
                {
                    new IngredientAmountEntity
                    {
                        Amount = 2,
                        Unit = Unit.Kg,
                        Ingredient = new IngredientEntity
                        {
                            Name = "Ingredient1Name",
                            Description = "Ingredient1Description"
                        }
                    },
                    new IngredientAmountEntity
                    {
                        Amount = 3,
                        Unit = Unit.L,
                        Ingredient = new IngredientEntity
                        {
                            Name = "Ingredient2Name",
                            Description = "Ingredient2Description"
                        }
                    }
                }
            };
            context.Recipes.Add(recipe);
            base.Seed(context);
        }
    }
}
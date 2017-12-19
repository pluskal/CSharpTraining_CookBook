using CookBook.BL.Models;

namespace CookBook.BL.Messages
{
    public class SelectedRecipeMessage
    {
        public RecipeListModel RecipeListModel { get; }

        public SelectedRecipeMessage(RecipeListModel recipeListModel)
        {
            RecipeListModel = recipeListModel;
        }
    }
}
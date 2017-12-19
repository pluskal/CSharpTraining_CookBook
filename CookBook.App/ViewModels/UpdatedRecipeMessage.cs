using CookBook.BL.Models;

namespace CookBook.App.ViewModels
{
    public class UpdatedRecipeMessage
    {
        public RecipeDetailModel Detail { get; }

        public UpdatedRecipeMessage(RecipeDetailModel detail)
        {
            Detail = detail;
        }
    }
}
using CookBook.BL.Models;

namespace CookBook.BL.Messages
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
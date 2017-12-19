using CookBook.App.ViewModels;
using CookBook.BL;

namespace CookBook.App
{
    public class ViewModelLocator
    {
        private readonly RecipeRepository _recipeRepository;

        public ViewModelLocator()
        {
            var recipeMapper = new RecipeMapper();
            _recipeRepository = new RecipeRepository(recipeMapper);
        }

        public MainViewModel MainViewModel => new MainViewModel();
        public RecipeListViewModel RecipeListViewModel => new RecipeListViewModel(_recipeRepository);
    }
}
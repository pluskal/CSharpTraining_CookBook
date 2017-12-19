using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CookBook.BL;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CookBook.App.ViewModels
{
    public class RecipeListViewModel : ViewModelBase
    {
        public RecipeListViewModel(RecipeRepository recipeRepository)
        {
            RecipeRepository = recipeRepository;
            if (!this.IsInDesignMode)
            {
                this.Recipes = this.RecipeRepository.GetAll();
            }
        }

        public RecipeListModel[] Recipes { get; set; }

        public RecipeRepository RecipeRepository { get; }

        public ICommand SelectRecipeCommand => new RelayCommand<RecipeListModel>(SelectRecipe);

        private void SelectRecipe(RecipeListModel recipeListModel)
        {
           this.MessengerInstance
                .Send<SelectedRecipeMessage>(
               new SelectedRecipeMessage(recipeListModel));
        }
    }
}

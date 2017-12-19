using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<RecipeListModel> _recipes;

        public RecipeListViewModel(RecipeRepository recipeRepository)
        {
            RecipeRepository = recipeRepository;
            if (!this.IsInDesignMode)
            {
                this.Recipes = new ObservableCollection<RecipeListModel>();
                OnLoad().ConfigureAwait(false);
            }
            this.MessengerInstance.Register<UpdatedRecipeMessage>(this,UpdateRecipesList);
        }

        private async Task OnLoad()
        {
            await Task.Run(async () =>
            {
                await Task.Delay(1000);
                this.Recipes = new ObservableCollection<RecipeListModel>(this.RecipeRepository.GetAll());
            });
        }


        private void UpdateRecipesList(UpdatedRecipeMessage recipeMessage)
        {
            this.Recipes.Add(new RecipeListModel()
            {
                Id = recipeMessage.Detail.Id,
                Name = recipeMessage.Detail.Name,
                Duration = recipeMessage.Detail.Duration,
                Type = recipeMessage.Detail.Type,
            });
        }

        public ObservableCollection<RecipeListModel> Recipes
        {
            get { return _recipes; }
            set
            {
                _recipes = value;
                this.RaisePropertyChanged();
            }
        }

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

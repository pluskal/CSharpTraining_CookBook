using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CookBook.BL;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CookBook.App.ViewModels
{
    public class RecipeDetailViewModel : ViewModelBase
    {
        private RecipeDetailModel _detail;
        public RecipeRepository RecipeRepository { get; }

        public RecipeDetailViewModel(RecipeRepository recipeRepository)
        {
            RecipeRepository = recipeRepository;
            this.MessengerInstance.Register<SelectedRecipeMessage>(this, ChangeSelectedRecipe);
            this.MessengerInstance.Register<NewRecipeMessage>(this, CreateNewRecipe);
            this.SaveRecipeDetailCommand = 
                new RelayCommand(() =>
                {
                    this.RecipeRepository.InsertOrUpdateRecipe(this.Detail);
                    this.MessengerInstance.Send<UpdatedRecipeMessage>(new UpdatedRecipeMessage(this.Detail));
                });
        }

        private void CreateNewRecipe(NewRecipeMessage obj)
        {
            Detail = new RecipeDetailModel();
        }

        private void ChangeSelectedRecipe(SelectedRecipeMessage meesage)
        {
            Detail = this.RecipeRepository.GetById(meesage.RecipeListModel.Id);
        }

        public RecipeDetailModel Detail
        {
            get => _detail;
            set
            {
                _detail = value;
                this.RaisePropertyChanged();
            }
        }

        public IList<FoodType> FoodTypes => Enum.GetValues(typeof(FoodType)).Cast<FoodType>().ToList();

        public ICommand SaveRecipeDetailCommand { get; }
    }
}
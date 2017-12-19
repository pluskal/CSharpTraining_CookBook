using System.Windows.Input;
using CookBook.BL.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CookBook.App.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public ICommand CreateRecipeCommand => new RelayCommand(
            () => {this.MessengerInstance.Send<NewRecipeMessage>(new NewRecipeMessage());});
    }
}
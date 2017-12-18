using System;
using CookBook.DAL.Entities;

namespace CookBook.BL.Models
{
    public class RecipeListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FoodType Type { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

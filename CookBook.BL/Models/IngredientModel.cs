using CookBook.DAL.Entities;

namespace CookBook.BL.Models
{
    public class IngredientModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public Unit Unit { get; set; }
    }
}
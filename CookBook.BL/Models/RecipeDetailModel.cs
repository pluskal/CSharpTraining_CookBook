using System;
using System.Collections.Generic;
using CookBook.DAL.Entities;

namespace CookBook.BL.Models
{
    public class RecipeDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FoodType Type { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();

        protected bool Equals(RecipeDetailModel other)
        {
            var members = Id.Equals(other.Id) && string.Equals(Name, other.Name) && Type == other.Type && string.Equals(Description, other.Description) && Duration.Equals(other.Duration);
            if (!members) return false;
            if(Ingredients.Count != other.Ingredients.Count) return false;
            foreach (var ingredientModel in Ingredients)
            {
                if (!other.Ingredients.Contains(ingredientModel)) return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RecipeDetailModel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Type;
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Duration.GetHashCode();
                hashCode = (hashCode * 397) ^ (Ingredients != null ? Ingredients.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Type)}: {Type}, {nameof(Description)}: {Description}, {nameof(Duration)}: {Duration}, {nameof(Ingredients)}: {Ingredients}";
        }
    }
}
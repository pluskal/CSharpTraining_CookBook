using System;
using CookBook.DAL.Entities;

namespace CookBook.BL.Models
{
    public class IngredienceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public Unit Unit { get; set; }

        protected bool Equals(IngredienceModel other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Description, other.Description) && Amount.Equals(other.Amount) && Unit == other.Unit;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IngredienceModel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Amount.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) Unit;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Description)}: {Description}, {nameof(Amount)}: {Amount}, {nameof(Unit)}: {Unit}";
        }
    }
}
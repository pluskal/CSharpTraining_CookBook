using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using System.Threading.Tasks;
using CookBook.DAL.Entities;

namespace CookBook.DAL
{
    public class CookBookDbContext:DbContext
    {
        public IDbSet<RecipeEntity> Recipes { get; set; }
        public IDbSet<IngredientEntity> Ingredients { get; set; }

        public CookBookDbContext():base("CookBookContext")
        {
            Database.SetInitializer<CookBookDbContext>(new CookBookDbInitializer());
        }
        /// <summary>
        /// Todo rewrite to proper truncation...
        /// </summary>
        public void TruncateTables()
        {
            this.Recipes.Clear(this);
            this.Ingredients.Clear(this);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RecipeEntity>().ToTable("Recipes");
            modelBuilder.Entity<IngredientEntity>().ToTable("Ingredients");
            modelBuilder.Entity<IngredientAmountEntity>().ToTable("IngredientAmounts");
           
            modelBuilder.Entity<RecipeEntity>()
                .HasMany<IngredientAmountEntity>(c=>c.Ingredients)
                .WithRequired(x=>x.Recipe)
                .WillCascadeOnDelete(true);
            
        }


    }
}

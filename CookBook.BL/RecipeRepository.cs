using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BL.Models;
using CookBook.DAL;

namespace CookBook.BL
{
    public class RecipeRepository
    {
        private readonly RecipeMapper _mapper;

        public RecipeRepository(RecipeMapper mapper)
        {
            _mapper = mapper;
        }

        public RecipeListModel[] GetAll()
        {
            using (var dbx = new CookBookDbContext())
            {
                return dbx.Recipes.Select(_mapper.Map).ToArray();
            }
        }
        public RecipeDetailModel GetById(Guid id)
        {
            using (var dbx = new CookBookDbContext())
            {
                return _mapper.MapDetailModel(
                    dbx.Recipes.Include(
                        r=>r.Ingredients.Select(i=>i.Ingredient)
                        ).FirstOrDefault(r => r.Id == id));
            }
        }

        public void InsertRecipe(RecipeDetailModel recipeDetailModel)
        {
            using (var dbx = new CookBookDbContext())
            {
                dbx.Recipes.Add(_mapper.Map(recipeDetailModel));
                dbx.SaveChanges();
            }
        }

        public void ClearDatabase()
        {
            using (var dbx = new CookBookDbContext())
            {
                dbx.TruncateTables();
            }
        }
    }
}

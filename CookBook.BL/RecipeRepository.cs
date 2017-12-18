using System.Collections.Generic;
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

        public void InsertRecipe(RecipDetailModel recipDetailModel)
        {
            using (var dbx = new CookBookDbContext())
            {
                dbx.Recipes.Add(_mapper.Map(recipDetailModel));
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

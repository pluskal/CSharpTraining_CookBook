using System.Data.Entity;
using System.Linq;

namespace CookBook.DAL
{
    public static class DbContextExtensions
    {
        public static void Clear<T>(this IDbSet<T> dbSet, DbContext dbContext) where T : class
        {
            foreach (var item in dbSet.ToArray())
            {
                dbSet.Remove(item);
            }
            dbContext.SaveChanges();
        }
    }
}
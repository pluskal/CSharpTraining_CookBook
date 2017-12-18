using CookBook.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CookBook.BL.Tests
{
    [TestFixture]
    public class RecipeRepositoryTests
    {
        [Test]
        public void GetAllTest()
        {
            var recipeRepository = new RecipeRepository(new RecipeMapper());
            var recipes = recipeRepository.GetAll();
            Assert.IsEmpty(recipes);
        }
    }
}
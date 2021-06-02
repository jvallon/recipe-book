using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IRecipeRepository : IRepositoryBase<Recipe>
    {
        public IEnumerable<Recipe> GetRecipes();
        public Recipe GetRecipeById(int recipeId);
        public Recipe GetRecipeDetailsById(int recipeId);
    }
}

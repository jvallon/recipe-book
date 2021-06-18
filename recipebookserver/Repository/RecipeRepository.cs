using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {

        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return FindAll()
                //.OrderBy(recipe => recipe.Title)
                .ToList();
        }

        public Recipe GetRecipeById(int recipeId)
        {
            return FindByCondition(r => r.RecipeId == recipeId)
                .FirstOrDefault();
        }

        public Recipe GetRecipeDetailsById(int recipeId)
        {
            return FindByCondition(r => r.RecipeId == recipeId)
                .Include(u => u.User)
                .Include(recipe => recipe.RecipeIngredients)
                    .ThenInclude(recipeIngredients => recipeIngredients.Ingredient)
                //.ThenInclude(ingredient => ingredient.Name)
                .Include(recipe => recipe.RecipeIngredients)
                    .ThenInclude(recipeIngredients => recipeIngredients.MeasurementQty)
                //    .ThenInclude(qty => qty.Amount)
                .Include(recipe => recipe.RecipeIngredients)
                    .ThenInclude(recipeIngredients => recipeIngredients.MeasurementUnit)
                //    .ThenInclude(unit => unit.Description)
                .FirstOrDefault();
        }

        public void CreateRecipe(Recipe recipe)
        {
            
            Create(recipe);
        }
    }
}

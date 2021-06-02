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
    public class FavoriteRepository : RepositoryBase<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }

        public IEnumerable<Favorite> GetFavoritesByUserId(int userId)
        {
            return FindByCondition(f => f.UserId == userId)
                .OrderBy(user => user.User.Username)
                .ToList();
        }

        public int GetFavoritesCountByRecipeId(int recipeId)
        {
            return FindByCondition(f => f.RecipeId == recipeId)
                .Count();
        }

        public void CreateFavorite(Favorite favorite)
        {
            Create(favorite);
        }
    }
}

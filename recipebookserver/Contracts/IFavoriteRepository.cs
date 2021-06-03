using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IFavoriteRepository : IRepositoryBase<Favorite>
    {
        public IEnumerable<Favorite> GetFavoritesByUserId(int userId);
        public int GetFavoritesCountByRecipeId(int recipeId);
        void CreateFavorite(Favorite favorite);
        void DeleteFavorite(Favorite favorite);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext repositoryContext;
        private IUserRepository userRepository;
        private IRecipeRepository recipeRepository;
        private IFavoriteRepository favoriteRepository;

        public IUserRepository User
        {
            get
            {
                if(userRepository == null)
                {
                    userRepository = new UserRepository(repositoryContext);
                }

                return userRepository;
            }
        }

        public IRecipeRepository Recipe
        {
            get
            {
                if(recipeRepository == null)
                {
                    recipeRepository = new RecipeRepository(repositoryContext);
                }

                return recipeRepository;
            }
        }

        public IFavoriteRepository Favorite
        {
            get
            {
                return favoriteRepository ??= new FavoriteRepository(repositoryContext);
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}

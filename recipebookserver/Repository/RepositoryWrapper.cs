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
        private IIngredientRepository ingredientRepository;
        private IMeasurementQtyRepository measurementQtyRepository;
        private IMeasurementUnitRepository measurementUnitRepository;

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

        public IIngredientRepository Ingredients
        {
            get
            {
                return ingredientRepository ??= new IngredientRepository(repositoryContext);
            }
        }

        public IMeasurementQtyRepository MeasurementQty
        {
            get
            {
                return measurementQtyRepository ??= new MeasurementQtyRepository(repositoryContext);
            }
        }

        public IMeasurementUnitRepository MeasurementUnit
        {
            get
            {
                return measurementUnitRepository ??= new MeasurementUnitRepository(repositoryContext);
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

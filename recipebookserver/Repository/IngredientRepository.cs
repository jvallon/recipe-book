using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Ingredient GetIngredientByName(string name)
        {
            return FindByCondition(i => i.Name == name).FirstOrDefault();
        }
    }
}

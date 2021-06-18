using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IIngredientRepository : IRepositoryBase<Ingredient>
    {
        public Ingredient GetIngredientByName(string name);
    }
}

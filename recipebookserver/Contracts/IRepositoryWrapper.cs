using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IRecipeRepository Recipe { get; }
        IFavoriteRepository Favorite { get; }
        IIngredientRepository Ingredients { get; }
        IMeasurementQtyRepository MeasurementQty { get; }
        IMeasurementUnitRepository MeasurementUnit { get; }

        void Save();
    }
}

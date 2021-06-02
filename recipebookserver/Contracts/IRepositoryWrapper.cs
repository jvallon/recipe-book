﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IRecipeRepository Recipe { get; }
        IFavoriteRepository Favorite { get; }
        void Save();
    }
}

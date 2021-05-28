﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int userId);
        User GetUserByIdWithDetails(int userId);
    }
}
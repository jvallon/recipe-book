using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetUsers();
        User GetUserById(string userId);
        User GetUserByAuthId(string authId);
        User GetUserByIdWithRecipes(string userId);
        User GetUserByIdWithFavorites(string userId);
        void CreateUser(User user);
    }
}

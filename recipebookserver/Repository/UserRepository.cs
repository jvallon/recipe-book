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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }

        public IEnumerable<User> GetUsers()
        {
            return FindAll()
                .OrderBy(user => user.Username)
                .ToList();
        }

        public User GetUserById(int id)
        {
            return FindByCondition(user => user.UserId == id).FirstOrDefault();
        }

        public User GetUserByIdWithRecipes(int userId)
        {
            return FindByCondition(user => user.UserId.Equals(userId))
                .Include(re => re.Recipes)
                .FirstOrDefault();
        }

        public User GetUserByIdWithFavorites(int userId)
        {
            return FindByCondition(user => user.UserId.Equals(userId))
                .Include(f => f.Favorites)
                .FirstOrDefault();
        }
    }
}

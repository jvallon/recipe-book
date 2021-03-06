using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UserDetailsDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }

        public IEnumerable<RecipeDto> Recipes { get; set; }
        public IEnumerable<FavoriteDto> Favorites { get; set; }
    }
}

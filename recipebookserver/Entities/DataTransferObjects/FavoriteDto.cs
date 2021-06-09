using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class FavoriteDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
    }
}

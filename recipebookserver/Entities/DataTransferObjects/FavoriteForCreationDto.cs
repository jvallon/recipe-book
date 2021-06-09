using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class FavoriteForCreationDto
    {
        public string UserId { get; set; }
        public int RecipeId { get; set; }
    }
}

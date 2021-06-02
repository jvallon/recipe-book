using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class FavoriteForCreationDto
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}

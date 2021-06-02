using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class RecipeWithDetailsDto
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan? PrepTime { get; set; }
        public TimeSpan? CookTime { get; set; }
        public string? ImageUrl { get; set; }

        public UserDto User { get; set; }
    }
}

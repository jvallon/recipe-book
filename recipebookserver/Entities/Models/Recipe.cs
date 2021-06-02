using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Entities.Models
{
    [Table("recipes")]
    public class Recipe
    {
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(45, ErrorMessage = "Title can't be more than 45 characters")]
        public string Title { get; set; }

        [StringLength(200, ErrorMessage = "Description can't be more than 200 characters")]
        public string Description { get; set; }

        public TimeSpan? PrepTime { get; set; }

        public TimeSpan? CookTime { get; set; }

        public string? ImageUrl { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

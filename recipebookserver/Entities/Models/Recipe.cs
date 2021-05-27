using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public DateTime? PrepTime { get; set; }

        public DateTime? CookTime { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

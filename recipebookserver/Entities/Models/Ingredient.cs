using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    [Table("ingredients")]
    public class Ingredient
    {
        public int IngredientId { get; set; }

        [StringLength(45, ErrorMessage = "Ingredient name cannot exceed 45 characters")]
        public string Name { get; set; }
    }
}

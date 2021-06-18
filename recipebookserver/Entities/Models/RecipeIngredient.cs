using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("recipe_ingredients")]
    public class RecipeIngredient
    {
        [Column("RecipeIngredientId")]
        public int Id { get; set; }
        
        public int RecipeId { get; set; }

        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

        [ForeignKey(nameof(MeasurementUnit))]
        public int MeasurementUnitsId { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }

        [ForeignKey(nameof(MeasurementQty))]
        public int MeasurementQtyId { get; set; }
        public MeasurementQty MeasurementQty { get; set; }
    }
}

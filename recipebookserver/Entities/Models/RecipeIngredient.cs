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

        public int IngredientId { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public Ingredient Ingredient { get; set; }

        public int MeasurementUnitsId { get; set; }
        [ForeignKey(nameof(MeasurementUnitsId))]
        public MeasurementUnit MeasurementUnit { get; set; }

        public int MeasurementQtyId { get; set; }
        [ForeignKey(nameof(MeasurementQtyId))]
        public MeasurementQty MeasurementQty { get; set; }
    }
}

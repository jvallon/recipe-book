using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class RecipeIngredientsDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        //public int IngredientId { get; set; }
        public IngredientDto Ingredient { get; set; }
        //public int MeasurementUnitsId { get; set; }
        public MeasurementUnitDto MeasurementUnit { get; set; }
        //public int MeasurementQtyId { get; set; }
        public MeasurementQtyDto MeasurementQty { get; set; }
    }
}

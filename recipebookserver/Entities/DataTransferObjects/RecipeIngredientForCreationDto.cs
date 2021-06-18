using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class RecipeIngredientForCreationDto
    {
        public IngredientForCreationDto Name { get; set; }
        public MeasurementUnitForCreationDto Unit { get; set; }
        public MeasurementQtyDto Qty { get; set; }
    }
}

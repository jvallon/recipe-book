using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    [Table("measurement_units")]
    public class MeasurementUnit
    {
        [Column("MeasurementUnitsId")]
        public int Id { get; set; }

        [Column("MeasurementDescription")]
        [StringLength(45, ErrorMessage = "Measurement unit description cannot exceed 45 characters")]
        public string MeasurementDescription { get; set; }
    }
}

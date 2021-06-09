using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    [Table("measurement_qty")]
    public class MeasurementQty
    {
        [Column("MeasurementQtyId")]
        public int Id { get; set; }

        [StringLength(45, ErrorMessage = "Measurement quantity cannot exceed 45 characters")]
        public string Amount { get; set; }
    }
}

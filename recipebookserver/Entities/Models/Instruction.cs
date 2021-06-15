using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Instruction
    {
        public int Step { get; set; }
        public string Description { get; set; }
    }
}

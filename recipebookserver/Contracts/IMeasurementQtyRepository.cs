using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IMeasurementQtyRepository
    {
        public MeasurementQty GetMeasurementQtyByAmount(string amount);
    }
}

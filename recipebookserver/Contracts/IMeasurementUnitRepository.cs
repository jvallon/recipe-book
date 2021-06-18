using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IMeasurementUnitRepository
    {
        public MeasurementUnit GetMeasurementUnitByDesc(string description);
    }
}

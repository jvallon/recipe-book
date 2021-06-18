using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities.Models;
using System.Linq;
using Entities;

namespace Repository
{
    public class MeasurementUnitRepository : RepositoryBase<MeasurementUnit>, IMeasurementUnitRepository
    {
        public MeasurementUnitRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public MeasurementUnit GetMeasurementUnitByDesc(string description)
        {
            return FindByCondition(m => m.MeasurementDescription == description).FirstOrDefault();
        }
    }
}

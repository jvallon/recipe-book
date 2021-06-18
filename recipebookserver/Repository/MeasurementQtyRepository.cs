using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Contracts;
using System.Linq;
using Entities;

namespace Repository
{
    public class MeasurementQtyRepository : RepositoryBase<MeasurementQty>, IMeasurementQtyRepository
    {
        public MeasurementQtyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public MeasurementQty GetMeasurementQtyByAmount(string amount)
        {
            return FindByCondition(mq => mq.Amount == amount).FirstOrDefault();
        }
    }
}

using EGIDAssessment.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Dtos
{
    public class OrderDto 
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public string Quantity { get; set; }
        public double Commission { get; set; }

        public virtual StokeDto Stoke { get; set; }

        public virtual BrokerDto Broker { get; set; }

        public Nullable<int> StockId { get; set; }

        public Nullable<int> BrokerId { get; set; }

        public Nullable<int> personId { get; set; } 
    }
}

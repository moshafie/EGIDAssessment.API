using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EGIDAssessment.Core.Domain.Entity
{
    public class Order
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public string Quantity { get; set; }
        public double Commission { get; set; }
        public Nullable<int> StockId { get; set; }
        public virtual Stock Stoke { get; set; }
       
        public Nullable<int> BrokerId { get; set; }
        public virtual Broker Broker { get; set; }
        public int? PersoneID { get; set; }
        public virtual Person? Person { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Entity
{
    public class Stock
    {

        public Stock()
        {
            this.order = new HashSet<Order>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Entity
{
    public class Person
    {
    
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("BrokerId")]
        public int? BrokerId { get; set; }
        public Broker Broker { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

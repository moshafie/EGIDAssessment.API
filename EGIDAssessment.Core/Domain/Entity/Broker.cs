using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Entity
{
    public class Broker
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
        public List<Person> person { get; set; }
    }
}

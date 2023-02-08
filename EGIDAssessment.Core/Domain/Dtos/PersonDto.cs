using EGIDAssessment.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Dtos
{
    public class PersonDto 
    {

        public int? Id { get; set; }
        public string? Name { get; set; }
   
        public int BrokerId { get; set; }
    }
}

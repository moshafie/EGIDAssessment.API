using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Dtos.BaseDto
{
    public abstract class BaseDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

using AutoMapper;
using EGIDAssessment.Core.Domain.Dtos.BaseDto;
using EGIDAssessment.Core.Domain.Entity;
using EGIDAssessment.Core.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Dtos
{
    public class BrokerDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        //public List<OrderDto> Orders { get; set; }
        public List<PersonDto> person { get; set; }
    }
}

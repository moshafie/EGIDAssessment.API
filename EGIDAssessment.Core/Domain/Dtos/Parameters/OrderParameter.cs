using AutoMapper;
using EGIDAssessment.Core.Domain.Dtos.BaseDto;
using EGIDAssessment.Core.Domain.Entity;
using EGIDAssessment.Core.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Dtos.Parameters
{
    public class OrderParameter 
    {

        public int ID { get; set; }
        public double Price { get; set; }
        public string Quantity { get; set; }
        public double Commission { get; set; }

        public Nullable< int >StockId{ get; set; }

        public Nullable<int> BrokerId { get; set; }
      
        public Nullable<int> personId { get; set; }


    }
}

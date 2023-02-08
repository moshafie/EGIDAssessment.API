using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Dtos
{
    public class StockNotify
    {
        public int StokeId { get; set; }
        public string StockName { get; set; }
        public decimal Price { get; set; }
    }
}

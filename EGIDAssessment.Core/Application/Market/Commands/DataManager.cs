using EGIDAssessment.Core.Domain.Dtos;
using EGIDAssessment.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Application.Commands
{
    public class DataManager : IDataManager
    {
        private readonly IStokeRepository stokeRepository;
        public DataManager(IStokeRepository stokeRepository)
        {
            this.stokeRepository = stokeRepository;
        }

        public async Task<List<StokeDto>> GetData()
        {
            var r = new Random();
            var data = await stokeRepository.GetAllStokes();
            foreach (var item in data)
            {
                item.Price = r.Next(1, 100);
            }
            return data;
        }


    }
}

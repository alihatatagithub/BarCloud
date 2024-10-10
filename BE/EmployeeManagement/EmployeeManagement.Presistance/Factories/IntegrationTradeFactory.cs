using EmployeeManagement.Contracts.Factories;
using EmployeeManagement.Data.DTO;
using EmployeeManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance.Factories
{
    public class IntegrationTradeFactory : IIntegrationTradeFactory
    {
        public List<IntegrationTrade> CreateIntegrationTrade(DTO dto)
        {
            return dto.results.Select(a => new IntegrationTrade
            {
                Volume = a.v,
                VolumeWeight = a.vw,
                Chair = a.c,
                Height = a.h,
                Low = a.l,
                NoOne = a.n,
                Open = a.o,
                Title = a.t
            }).ToList();
        }
    }
}

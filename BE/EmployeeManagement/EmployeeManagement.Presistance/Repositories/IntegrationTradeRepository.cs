using EmployeeManagement.Contracts.Repositories;
using EmployeeManagement.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance.Repositories
{
    public class IntegrationTradeRepository : IIntegrationTradeRepository
    {
        private readonly EmployeeEntities EmployeeEntities;
        public IntegrationTradeRepository(EmployeeEntities context)
        {
            EmployeeEntities = context;
        }
        public async Task Create(List<IntegrationTrade> integrationTrades)
        {
            await EmployeeEntities.IntegrationTrades.AddRangeAsync(integrationTrades);
        }
    }
}

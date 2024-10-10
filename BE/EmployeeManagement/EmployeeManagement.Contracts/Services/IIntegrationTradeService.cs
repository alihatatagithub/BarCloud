using EmployeeManagement.Contracts.Common;
using EmployeeManagement.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.Services
{
    public interface IIntegrationTradeService 
    {
        Task CreateIntegrationTrade();
    }
}

using EmployeeManagement.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using EmployeeManagement.Data.DTO;
using EmployeeManagement.Contracts.Services;
using EmployeeManagement.Contracts.Factories;

namespace EmployeeManagement.Services
{
    public class IntegrationTradeService : IIntegrationTradeService
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly Lazy<IHttpClientFactory> _clientFactory;
        private readonly Lazy<IIntegrationTradeFactory> _integrationFactory;

        public IntegrationTradeService(Lazy<IUnitOfWork> unitOfWork, Lazy<IHttpClientFactory> clientFactory, Lazy<IIntegrationTradeFactory> integrationFactory)
        {
            _unitOfWork = unitOfWork;
            _clientFactory = clientFactory;
            _integrationFactory = integrationFactory;

        }
        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IHttpClientFactory ClientFactory => _clientFactory.Value;
        private IIntegrationTradeFactory IntegrationFactory => _integrationFactory.Value;

        public async Task CreateIntegrationTrade()
        {
            var client = ClientFactory.CreateClient();
            var httpResponse = await client.GetAsync("https://api.polygon.io/v2/aggs/ticker/AAPL/range/1/day/2023-01-09/2023-02-10?adjusted=true&sort=asc&apiKey=KNMJCHN85c522SZEePlWMNd76qiQozqc");
            var result = JsonConvert.DeserializeObject<DTO>(await httpResponse.Content.ReadAsStringAsync());
            var integrationTrades = IntegrationFactory.CreateIntegrationTrade(result);
            await UnitOfWork.IntegrationTradeRepository.Create(integrationTrades);
            await UnitOfWork.SaveChangesAsync();
        }
    }

}

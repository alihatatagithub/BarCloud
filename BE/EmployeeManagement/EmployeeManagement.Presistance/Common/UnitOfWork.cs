using EmployeeManagement.Contracts.Common;
using EmployeeManagement.Contracts.Repositories;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Presistance.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeEntities _context;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;
        private readonly Lazy<IIntegrationTradeRepository> _integrationTradeRepository;
        public UnitOfWork(EmployeeEntities context
            , Lazy<IUserRepository> userRepository
            , Lazy<IEmployeeRepository> employeeRepository
            , Lazy<IDepartmentRepository> departmentRepository
            , Lazy<IIntegrationTradeRepository> integrationTradeRepository)
        {
            _userRepository = userRepository;
            _context = context;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _integrationTradeRepository = integrationTradeRepository;
        }
        public IUserRepository UserRepository => _userRepository.Value;
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;
        public IIntegrationTradeRepository IntegrationTradeRepository => _integrationTradeRepository.Value;
        private EmployeeEntities BookEntities => _context;


        public async Task SaveChangesAsync()
        {
             await BookEntities.SaveChangesAsync();
        }
    }
}

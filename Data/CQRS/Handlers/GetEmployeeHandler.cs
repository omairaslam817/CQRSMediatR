using CQRSMediatR.Data.CQRS.Queries;
using CQRSMediatR.Models;
using CQRSMediatR.Services;
using MediatR;

namespace CQRSMediatR.Data.CQRS.Handlers
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>//query and employee
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeByIdAysnc(request.Id);
        }
    }
}

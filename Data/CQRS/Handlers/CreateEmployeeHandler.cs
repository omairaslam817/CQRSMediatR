using CQRSMediatR.Data.CQRS.Command;
using CQRSMediatR.Models;
using CQRSMediatR.Services;
using MediatR;

namespace CQRSMediatR.Data.CQRS.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //request has every param we just need to make object to pass from it,we have to create new object that is requires
            Employee employee = new Employee()
            {
                 Name = request.Name,
                  Address = request.Address,
                   Email = request.Email,
                    Phone = request.Phone
            };
            return await _employeeRepository.AddEmployeeAysnc(employee);
        }
    }
}

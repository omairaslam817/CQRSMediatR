using CQRSMediatR.Data.CQRS.Command;
using CQRSMediatR.Services;
using MediatR;

namespace CQRSMediatR.Data.CQRS.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAysnc(request.Id);
            if (employee == null)
            {
                return default;
            }
            //request has all data So we will shfit data to Employee class
            employee.Address = request.Address;
            employee.Phone = request.Phone;
            employee.Name = request.Name;
            employee.Email = request.Email;
            return await _employeeRepository.UpdateEmployeeAysnc(employee);
        }
    }
}

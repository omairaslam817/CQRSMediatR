using CQRSMediatR.Data.CQRS.Command;
using CQRSMediatR.Services;
using MediatR;

namespace CQRSMediatR.Data.CQRS.Handlers
{
    //Step 1 create Handlers then make controller on this base and use MediatR in controler
    //In bw MediatR and Controller Query and Command will communicate  Not Handler,because mediartoR use Query and Handler 
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int> //command that we create for delete opertion
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAysnc(request.Id);
            if (employee == null) { return default; }
            return await _employeeRepository.DeleteEmployeeAysnc(request.Id);
        }
    }
}

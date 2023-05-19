using CQRSMediatR.Data.CQRS.Queries;
using CQRSMediatR.Models;
using CQRSMediatR.Services;
using MediatR;

namespace CQRSMediatR.Data.CQRS.Handlers
{
    //Use repositiry in handler,first param is query 2nd is response type
    // always use repository or inject repo in Hnalder or we can use data context directly if we not use repo pattern
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuey, List<Employee>>//Query,list of employee
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeListHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<Employee>> Handle(GetEmployeeListQuey request, CancellationToken cancellationToken)
        {
            //request param has list of employee whole
            return await _employeeRepository.GetEmployeesListAysnc();
        }
    }
}

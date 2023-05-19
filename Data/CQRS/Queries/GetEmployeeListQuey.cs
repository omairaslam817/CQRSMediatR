using CQRSMediatR.Models;
using MediatR;

namespace CQRSMediatR.Data.CQRS.Queries
{
    //every metjod or request has separet class 
    public class GetEmployeeListQuey:IRequest<List<Employee>>//GetEmployeeListQuey will return list of employees
    {
    }
}

using CQRSMediatR.Models;
using MediatR;

namespace CQRSMediatR.Data.CQRS.Queries
{
    public class GetEmployeeByIdQuery:IRequest<Employee> //will return employee by id,so we have to know id so take id as param
    {
        public int Id { get; set; } //pass Id
    }
}

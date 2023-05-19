using CQRSMediatR.Data.CQRS.Command;
using CQRSMediatR.Data.CQRS.Queries;
using CQRSMediatR.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<Employee>> GetEmployeesListAsync()
        {
            var employeeList = await _mediator.Send(new GetEmployeeListQuey());
            //Not call Handler here ,Mediator auto will use Handler,just send commnad or Query object
            return employeeList;
        }
        [HttpGet("{id}")]
        public async Task<Employee> EmployeeByIdAsync(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id});
            return employee;
        }
        [HttpPost]
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeReturn = await _mediator.Send(new CreateEmployeeCommand(
                //pass Constructor parameter
                 employee.Name,
                 employee.Address,
                employee.Email,
                employee.Phone
            ));
            return employeeReturn;
        }
        [HttpPut]
        public async Task<int> UpdateEmployee(Employee employee)
        {
            var employeeReturn = await _mediator.Send(new UpdateEmployeeCommand( //All data is going into query and command not in Hnadler beacuse MediatR will use this data to communicate through Handlers functions
                 //pass Constructor parameter
                 employee.Id,
                 employee.Name,
                 employee.Address,
                employee.Email,
                employee.Phone
            ));
            return employeeReturn;
        }
        [HttpGet("{id}")]
        public async Task<int> Delete(int id)
        {
            //MediatoR will use Handler internally ,pass obly Query or command from mediatoR
            //Register  Mediatorin DI
            return await _mediator.Send(new DeleteEmployeeCommand() { Id = id});

        }
    }
}

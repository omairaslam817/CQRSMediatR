using CQRSMediatR.Data;
using CQRSMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Services
{
    //In old MVC we preparea a Model class and then create repository/Service for that model,after register
    // we use it in controller,we direclty access object
    //We can not communicate directly to objects from controller,it mean we can't direct comminicate to employee class directly
    //it will handle by MediatR through handlers

    //After repo DI ,we use in all methods,this mean we direlcty works with objects in between has no layer,
    //Respoitory has direct context ,mean 
    //When we will use repository in controller ,we directly work with object,IT OLD METHOD,on which we can directly access 

    //Steps
    //if we have datastore ,make query and  command handler from this store,after this use MediatR in controller
    //Why need
    //Before that we do all work using 1 class by making repo ,use it for crud operations.but
    //now we will do all crud operation using seprate classes,this will give loose coupling to mvc pattern
    //objects are less couple and remove dependdency ,use it for send/receive and broadcasting and reuse classes
    //I f we work with 1 object and direct commnicate with object this will increase complexity.
    //for every query command make seprate class
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> AddEmployeeAysnc(Employee employee)
        {
            var result = _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAysnc(int Id)
        {
            var filterData = _dbContext.Employees.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Employees.Remove(filterData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAysnc(int Id)
        {
            var filterData = await _dbContext.Employees.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return filterData;
        }

        public Task<List<Employee>> GetEmployeesListAysnc()
        {
            var filterData = _dbContext.Employees.ToListAsync();
            return filterData;
        }

        public async Task<int> UpdateEmployeeAysnc(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

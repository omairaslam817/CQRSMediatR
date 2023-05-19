using CQRSMediatR.Models;

namespace CQRSMediatR.Services
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesListAysnc();
        Task<Employee> GetEmployeeByIdAysnc(int Id);
        Task<Employee> AddEmployeeAysnc(Employee employee);
        Task<int> UpdateEmployeeAysnc(Employee employee);
        Task<int> DeleteEmployeeAysnc(int Id);
       
    }
}

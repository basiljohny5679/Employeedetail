
using EmployeeDetail.Model;

namespace EmployeeDetail.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDetails>> GetEmployeesAsync();
        Task<EmployeeDetails> GetEmployeeByIdAsync(Guid id);
        Task AddEmployeeAsync(EmployeeDetails employee);
        Task<EmployeeDetails> UpdateEmployeeAsync(Guid id,EmployeeDetails employee);
        Task DeleteEmployeeAsync(Guid id);
        
    }
}

using EmployeeDetail.Model;

namespace EmployeeDetail.Interface
{
    public interface IEmployeeService
    {
      public  Task<IEnumerable<EmployeeDetails>> GetEmployeesAsync();
       public Task<EmployeeDetails> GetEmployeeByIdAsync(Guid id);
        public Task AddEmployeeAsync(EmployeeDetails employee);
        public Task<EmployeeDetails> UpdateEmployeeAsync(Guid id, EmployeeDetails employee);
        public Task DeleteEmployeeAsync(Guid id);


    }
}

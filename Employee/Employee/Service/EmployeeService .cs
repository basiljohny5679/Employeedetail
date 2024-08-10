using EmployeeDetail.Interface;
using EmployeeDetail.Model;

namespace EmployeeDetail.Service
{
    public class EmployeeService : IEmployeeService
    {
       


        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDetails>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }

        public async Task<EmployeeDetails> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task AddEmployeeAsync(EmployeeDetails employee)
        {
            employee.EmployeeId = Guid.NewGuid(); 
            await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<EmployeeDetails> UpdateEmployeeAsync(Guid id,EmployeeDetails employee)
        {
            return await _employeeRepository.UpdateEmployeeAsync(id ,employee);
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }
    

}
}

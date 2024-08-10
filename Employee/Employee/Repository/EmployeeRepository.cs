using EmployeeDetail.Interface;
using EmployeeDetail.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetail.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
       



        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDetails>> GetEmployeesAsync()
        {
            try
            {
                return await _context.EmployeesDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"An error occurred while retrieving employees: {ex.Message}", ex);
            }
        }

        public async Task<EmployeeDetails> GetEmployeeByIdAsync(Guid id)
        {
            try
            {
                return await _context.EmployeesDetails.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"An error occurred while retrieving the employee: {ex.Message}", ex);
            }
        }

        public async Task AddEmployeeAsync(EmployeeDetails employee)
        {
            try
            {
                await _context.EmployeesDetails.AddAsync(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"An error occurred while adding the employee: {ex.Message}", ex);
            }
        }

        public async Task<EmployeeDetails> UpdateEmployeeAsync(Guid id, EmployeeDetails employee)
        {
            try
            {
                
                var Details = await _context.EmployeesDetails.FirstOrDefaultAsync(e => e.EmployeeId == id);
                if (Details == null) 
                {
                    Console.WriteLine("not found");
                   
                }
                Details.EmployeeName = employee.EmployeeName;
                Details.EmailId = employee.EmailId;
                Details.MobileNumber = employee.MobileNumber;
                
                await _context.SaveChangesAsync();
                return Details;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"An error occurred while updating the employee: {ex.Message}", ex);
            }
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            try
            {
                var employee = await _context.EmployeesDetails.FindAsync(id);
                if (employee == null)
                {
                    throw new Exception("Employee not found");
                }

                _context.EmployeesDetails.Remove(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"An error occurred while deleting the employee: {ex.Message}", ex);
            }
        }
    

}
}

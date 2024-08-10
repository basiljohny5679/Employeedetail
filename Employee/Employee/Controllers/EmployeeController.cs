using EmployeeDetail.Interface;
using EmployeeDetail.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

 


        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        [Route("/Employee/List")]
        public async Task<ActionResult<IEnumerable<EmployeeDetails>>> GetEmployees()
        {
            try
            {
                return Ok(await _employeeService.GetEmployeesAsync());
                
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Employee/5
        [HttpGet]
        [Route("/Employee")]
        public async Task<ActionResult<EmployeeDetails>> GetEmployee(Guid id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Employee
        [HttpPost]
        [Route("/Employee/Add")]
        public async Task<ActionResult<EmployeeDetails>> PostEmployee(EmployeeDetails employee)
        {
            try
            {
                await _employeeService.AddEmployeeAsync(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Employee/5
        [HttpPut]
        [Route("/Employee/Update")]
        public async Task<IActionResult> PutEmployee(Guid id, EmployeeDetails employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            try
            {
              var details=  await _employeeService.UpdateEmployeeAsync(id, employee);
                return Ok(details);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Employee/5
        [HttpDelete]
        [Route("/Employee/Delete")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    











}
}

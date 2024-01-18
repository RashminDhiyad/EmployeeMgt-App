using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeManagementDBContext _context;
        public EmployeesController(EmployeeManagementDBContext employeeManagementDBContext)
        {
            _context = employeeManagementDBContext;
        }

        // Get: api/Employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        // Get: api/Employees/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employeeRequest)
        {
            _context.Employees.Add(employeeRequest);
            await _context.SaveChangesAsync();
            return Ok(employeeRequest);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee updateEmployeeRequest)
        {
            if (id != updateEmployeeRequest.Id)
            {
                return BadRequest();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.FirstName = updateEmployeeRequest.FirstName;
            employee.LastName = updateEmployeeRequest.LastName;
            employee.EmailAddress = updateEmployeeRequest.EmailAddress;
            employee.PhoneNumber =  updateEmployeeRequest.PhoneNumber;
            employee.DOB = updateEmployeeRequest.DOB;
            employee.Gender = updateEmployeeRequest.Gender;
            employee.Designation = updateEmployeeRequest.Designation;
            employee.Address = updateEmployeeRequest.Address;
            employee.City = updateEmployeeRequest.City;
            employee.PostalCode = updateEmployeeRequest.PostalCode;
            try
            {
                await _context.SaveChangesAsync();

                return Ok(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}

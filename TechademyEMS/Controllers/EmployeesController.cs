using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using TechademyEMS.DatabaseContext;
using TechademyEMS.Models.Employee_Model;
using TechademyEMS.Models.EmployeeModel;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly EMSDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(EMSDbContext context,IEmployeeRepository employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        // GET: api/Employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                return Ok(_employeeRepository.GetAll());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                return Ok(_employeeRepository.GetById(id));
            }
            catch { return NotFound(); }
        }

        // PUT: api/Employees/5
        
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, AddEmployeeRequest employee)
        {
            try
            {
                var emp = _employeeRepository.UpdateEmployee(employee, id);
              return Ok(emp);
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
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
            
        }

        // POST: api/Employees
        
        [HttpPost]
        public ActionResult PostEmployee(AddEmployeeRequest employee)
        {
            try
            {
                return Ok(_employeeRepository.AddEmployee(employee));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                bool delete = _employeeRepository.DeleteEmployee(id);
                if (delete)
                    return Ok();
                else
                    return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}

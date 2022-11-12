using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechademyEMS.DatabaseContext;
using TechademyEMS.Models;
using TechademyEMS.Models.PaymentRulesModel;
using TechademyEMS.Models.Working_Hours_Model;
using TechademyEMS.Models.WorkingHoursModel;
using TechademyEMS.Repository.Implementation;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHoursController : ControllerBase
    {
        private readonly EMSDbContext _context;
        private readonly IWorkingHoursRepository _workingHoursRepository;

        public WorkingHoursController(EMSDbContext context,IWorkingHoursRepository workingHoursRepository)
        {
            _context = context;
            _workingHoursRepository = workingHoursRepository;   
        }

        // GET: api/WorkingHours
        [HttpGet]
        public IActionResult GetWorkHours()
        {
            try
            {

                var workHours = _workingHoursRepository.GetAll();
                return Ok(workHours);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/WorkingHours/5
        [HttpGet("{id}")]
        public IActionResult GetWorkingHours(int id)
        {
            try
            {
                var workingHours = _workingHoursRepository.GetById(id);

                if (workingHours == null)
                {
                    return NotFound();
                }

                return Ok(workingHours);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/WorkingHours/5
     
        [HttpPut("{id}")]
        public IActionResult PutWorkingHours(int id, AddWorkingHours workingHours)
        {
            try
            {
                var hours = _workingHoursRepository.Update(workingHours, id);
                return Ok(hours);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkingHoursExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/WorkingHours
       
        [HttpPost]
        public IActionResult PostWorkingHours(AddWorkingHours workingHours)
        {
            try
            {
                return Ok(_workingHoursRepository.Add(workingHours));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/WorkingHours/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkingHours(int id)
        {
            try
            {
                bool delete = _workingHoursRepository.Delete(id);
                if (delete)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool WorkingHoursExists(int id)
        {
            return _context.WorkHours.Any(e => e.Id == id);
        }
    }
}

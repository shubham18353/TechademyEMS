using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechademyEMS.DatabaseContext;
using TechademyEMS.Models.DesignationModel;
using TechademyEMS.Models.EmployeeModel;
using TechademyEMS.Models.LeaveRequest_Model;
using TechademyEMS.Models.LeaveRequestModel;
using TechademyEMS.Repository.Implementation;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly EMSDbContext _context;
        private readonly ILeaveRequestRepository leaveRequestRepository;

        public LeaveRequestsController(EMSDbContext context,ILeaveRequestRepository leaveRequestRepository)
        {
            _context = context;
            this.leaveRequestRepository = leaveRequestRepository;
        }

        // GET: api/LeaveRequests
        [HttpGet]
        public IActionResult GetLeaveRequests()
        {
            try
            {
                return Ok(leaveRequestRepository.GetAll());
            }
            catch
            {
                return NoContent();
            }
        }

        // GET: api/LeaveRequests/5
        [HttpGet("{id}")]
        public IActionResult GetLeaveRequest(int id)
        {
            try
            {
                var leaveRequest = leaveRequestRepository.GetById(id);

                if (leaveRequest == null)
                {
                    return NotFound();
                }
                return Ok(leaveRequest);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/LeaveRequests/5
       
        [HttpPut("{id}")]
        public IActionResult PutLeaveRequest(int id, AddLeaveRequest leaveRequest)
        {
            try
            {
                var emp = leaveRequestRepository.Update(leaveRequest, id);
                return Ok(emp);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveRequestExists(id))
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

        // POST: api/LeaveRequests
        
        [HttpPost]
        public IActionResult PostLeaveRequest(AddLeaveRequest leaveRequest)
        {
            try
            {
                return Ok(leaveRequestRepository.Add(leaveRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/LeaveRequests/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLeaveRequest(int id)
        {
            try
            {
                bool delete = leaveRequestRepository.Delete(id);
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

        private bool LeaveRequestExists(int id)
        {
            return _context.LeaveRequests.Any(e => e.LeaveId == id);
        }
    }
}

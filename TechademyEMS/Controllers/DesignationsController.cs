using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechademyEMS.DatabaseContext;
using TechademyEMS.Models.Designation_Model;
using TechademyEMS.Models.DesignationModel;
using TechademyEMS.Models.EmployeeModel;
using TechademyEMS.Repository.Implementation;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationsController : ControllerBase
    {
        private readonly EMSDbContext _context;
        private readonly IDesignationRepository _designationRepository;

        public DesignationsController(EMSDbContext context,IDesignationRepository designationRepository)
        {
            _context = context;
            _designationRepository = designationRepository;
        }

        // GET: api/Designations
        [HttpGet]
        public IActionResult GetDesignations()
        {
            try
            {
                return Ok(_designationRepository.GetAll());
            }
            catch
            {
                return NoContent();
            }
        }

        // GET: api/Designations/5
        [HttpGet("{id}")]
        public IActionResult GetDesignation(int id)
        {
            try
            {
                var designation = _designationRepository.GetById(id);

                if (designation == null)
                {
                    return NotFound();
                }
                return Ok(designation);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message) ;
            }
        }

        // PUT: api/Designations/5
       
        [HttpPut("{id}")]
        public IActionResult PutDesignation(int id, AddDesignationRequest designation)
        {
            try
            {
                var emp = _designationRepository.Update(designation, id);
                return Ok(emp);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationExists(id))
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

        // POST: api/Designations
      
        [HttpPost]
        public IActionResult PostDesignation(AddDesignationRequest designation)
        {
            try
            {
                return Ok(_designationRepository.Add(designation));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        // DELETE: api/Designations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDesignation(int id)
        {
            try
            {
                bool delete = _designationRepository.Delete(id);
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

        private bool DesignationExists(int id)
        {
            return _context.Designations.Any(e => e.DesigId == id);
        }
    }
}

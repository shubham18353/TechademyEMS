using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechademyEMS.DatabaseContext;
using TechademyEMS.Models;
using TechademyEMS.Models.EmployeeModel;
using TechademyEMS.Models.Payment_Rules_Model;
using TechademyEMS.Models.PaymentRulesModel;
using TechademyEMS.Repository.Implementation;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentRulesController : ControllerBase
    {
        private readonly EMSDbContext _context;
        private readonly IPaymentRulesRepository _paymentRulesRepository;

        public PaymentRulesController(EMSDbContext context,IPaymentRulesRepository paymentRulesRepository)
        {
            _context = context;
            _paymentRulesRepository = paymentRulesRepository;
        }

        // GET: api/PaymentRules
        [HttpGet]
        public IActionResult GetPaymentRules()
        {
            try
            {
                var paymentRules = _paymentRulesRepository.GetAll();
                return Ok(paymentRules);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/PaymentRules/5
        [HttpGet("{id}")]
        public IActionResult GetPaymentRules(int id)
        {
            try
            {
                var paymentRules = _paymentRulesRepository.GetById(id);

                if (paymentRules == null)
                {
                    return NotFound();
                }

                return Ok(paymentRules);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/PaymentRules/5
        
        [HttpPut("{id}")]
        public IActionResult PutPaymentRules(int id, PaymentRulesRequest paymentRules)
        {
            try
            {
                var rules = _paymentRulesRepository.Update(paymentRules, id);
                return Ok(rules);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentRulesExists(id))
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

        // POST: api/PaymentRules
       
        [HttpPost]
        public IActionResult PostPaymentRules(PaymentRulesRequest paymentRules)
        {
            try
            {
                return Ok(_paymentRulesRepository.Add(paymentRules));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // DELETE: api/PaymentRules/5
        [HttpDelete("{id}")]
        public IActionResult DeletePaymentRules(int id)
        {
            try
            {
                bool delete = _paymentRulesRepository.Delete(id);
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

        private bool PaymentRulesExists(int id)
        {
            return _context.PaymentRules.Any(e => e.Payscale == id);
        }
    }
}

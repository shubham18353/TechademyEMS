using TechademyEMS.DatabaseContext;
using TechademyEMS.Models.Payment_Rules_Model;
using TechademyEMS.Models.PaymentRulesModel;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Repository.Implementation
{
    public class PaymentRulesRepository:IPaymentRulesRepository
    {
        private readonly EMSDbContext _context;

        public PaymentRulesRepository(EMSDbContext context)
        {
            _context = context;
        }

        public PaymentRules Add(PaymentRulesRequest request)
        {
            try
            {
                PaymentRules paymentRules = new PaymentRules();
                paymentRules.FixedPay = request.FixedPay;
                paymentRules.VariablePay = request.VariablePay;
                paymentRules.CostToCompany = request.CostToCompany;
                

                _context.PaymentRules.Add(paymentRules);
                _context.SaveChangesAsync();
                return paymentRules;
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var request = _context.PaymentRules.FirstOrDefault(x => x.Payscale == id);
                if (request != null)
                {
                    _context.PaymentRules.Remove(request);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new Exception("Payment Rules can't be deleted");
            }
        }

        public List<PaymentRules> GetAll()
        {
            try
            {
                List<PaymentRules> requests = _context.PaymentRules.ToList();
                return requests;
            }
            catch
            {
                throw new Exception("Server Error! Can't load Payment Rules");
            }
        }

        public PaymentRules GetById(int id)
        {
            var request = _context.PaymentRules.Find(id);
            if (request != null)
                return request;
            else
                throw new Exception("Payment Rules Id mismatch!");
        }

        public PaymentRules Update(PaymentRulesRequest request, int id)
        {
            try
            {
                var paymentRules = _context.PaymentRules.Find(id);
                if (paymentRules != null)
                {
                    paymentRules.FixedPay = request.FixedPay;
                    paymentRules.VariablePay = request.VariablePay;
                    paymentRules.CostToCompany = request.CostToCompany;

                    
                    _context.SaveChangesAsync();
                    return paymentRules;
                }
                else
                    throw new Exception("Payment Rules Not Found!");
            }
            catch
            {
                throw;
            }
        }
    }
}

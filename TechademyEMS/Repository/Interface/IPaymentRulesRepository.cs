using TechademyEMS.Models.Payment_Rules_Model;
using TechademyEMS.Models.PaymentRulesModel;

namespace TechademyEMS.Repository.Interface
{
    public interface IPaymentRulesRepository
    {
        public List<PaymentRules> GetAll();
        public PaymentRules GetById(int id);
        public PaymentRules Add(PaymentRulesRequest rules);
        public PaymentRules Update(PaymentRulesRequest rules, int id);
        bool Delete(int id);
    }
}

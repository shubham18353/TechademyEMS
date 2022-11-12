using TechademyEMS.Models.EmployeeModel;

namespace TechademyEMS.Models.Payment_Rules_Model
{
    public class PaymentRulesRequest
    {
        public decimal FixedPay { get; set; }
        public decimal VariablePay { get; set; }
        public decimal CostToCompany { get; set; }
       
    }
}

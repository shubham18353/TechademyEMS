using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TechademyEMS.Models.EmployeeModel;

namespace TechademyEMS.Models.PaymentRulesModel

{
    public class PaymentRules
    {
        [NotNull, Key]
        public int Payscale { get; set; }
        public decimal FixedPay { get; set; }
        public decimal VariablePay { get; set; }
        public decimal CostToCompany { get; set; }
       

    }
}

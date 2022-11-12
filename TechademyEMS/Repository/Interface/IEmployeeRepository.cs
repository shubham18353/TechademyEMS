using TechademyEMS.Models.Employee_Model;
using TechademyEMS.Models.EmployeeModel;

namespace TechademyEMS.Repository.Interface
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAll();
        public Employee GetById(int id);
        public Employee AddEmployee(AddEmployeeRequest emp);
        public Employee UpdateEmployee(AddEmployeeRequest emp,int id);
        bool DeleteEmployee(int id);
    }
}

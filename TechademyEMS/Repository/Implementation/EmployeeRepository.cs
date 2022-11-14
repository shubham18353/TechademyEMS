using TechademyEMS.DatabaseContext;
using TechademyEMS.Models.DesignationModel;
using TechademyEMS.Models.Employee_Model;
using TechademyEMS.Models.EmployeeModel;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Repository.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EMSDbContext _context;

        public EmployeeRepository(EMSDbContext context)
        {
            _context = context;
        }

        public Employee AddEmployee(AddEmployeeRequest emp)
        {
            try
            {
                Employee employee = new Employee();
                employee.Name = emp.Name;
                employee.Email = emp.Email;
                employee.Phone = emp.Phone;
                employee.Address = emp.Address;
                employee.IsWorking = emp.IsWorking;
                employee.DesigId= emp.DesigId;
                employee.Payscale=emp.Payscale;
                employee.LeaveId= emp.LeaveId;
               _context.Employees.Add(employee);
                _context.SaveChanges();
                return employee;
            }
            catch
            {
                throw new Exception("Could Not Process Requuest!");
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new Exception("Employee can't be deleted");
            }
        }

        public List<Employee> GetAll()
        {
            try
            {
                List<Employee> employees = _context.Employees.ToList();
                return employees;
            }
            catch
            {
                throw new Exception("Server Error! Can't load Employees");
            }
        }

        public Employee GetById(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);
                if (employee != null)
                    return employee;
                else
                    throw new Exception("Employee Id mismatch! ");
            }
            catch
            {
                throw;
            }
        }

        public Employee UpdateEmployee(AddEmployeeRequest emp,int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);
                if (employee != null)
                {
                    employee.Name = emp.Name;
                    employee.Email = emp.Email;
                    employee.Phone = emp.Phone;
                    employee.Address = emp.Address;
                    employee.IsWorking = emp.IsWorking;
                    employee.DesigId = emp.DesigId;
                    employee.Payscale = emp.Payscale;
                    employee.LeaveId = emp.LeaveId;
                   
                    _context.SaveChangesAsync();
                    return employee;
                }
                else
                {
                    throw new Exception("Id not Found!");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

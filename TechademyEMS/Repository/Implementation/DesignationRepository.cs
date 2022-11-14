using TechademyEMS.DatabaseContext;
using TechademyEMS.Models.Designation_Model;
using TechademyEMS.Models.DesignationModel;

using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Repository.Implementation
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly EMSDbContext _context;

        public DesignationRepository(EMSDbContext context)
        {
            _context = context;
        }

        public Designation Add(AddDesignationRequest des)
        {
            try
            {
                Designation designation = new Designation();
                designation.DesignationName = des.DesignationName;
                designation.Department = des.Department;
                designation.Role = des.Role;
               
                _context.Designations.Add(designation);
                _context.SaveChangesAsync();
                return designation;
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
                var des = _context.Designations.FirstOrDefault(x => x.DesigId == id);
                if (des != null)
                {
                    _context.Designations.Remove(des);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new Exception("Designation can't be deleted");
            }
        }

        public List<Designation> GetAll()
        {
            try
            {
                List<Designation> dess = _context.Designations.ToList();
                return dess;
            }
            catch
            {
                throw new Exception("Server Error! Can't load Designations");
            }
        }

        public Designation GetById(int id)
        {
            try
            {
                var des = _context.Designations.Find(id);
                if (des != null)
                    return des;
                else
                    throw new Exception("Designation Id mismatch! ");
            }
            catch
            {
                throw;
            }
        }

        public Designation Update(AddDesignationRequest des,int id)
        {
            try
            {
                var designation = _context.Designations.Find(id);
                if (designation != null)
                {
                    designation.DesignationName = des.DesignationName;
                    designation.Department = des.Department;
                    designation.Role = des.Role;

                    
                    _context.SaveChangesAsync();
                    return designation;
                }
                else
                    throw new Exception("Designation Not Found!");
            }
            catch
            {
                throw;
            }
        }
    }
}

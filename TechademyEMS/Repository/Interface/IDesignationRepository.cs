using TechademyEMS.Models.Designation_Model;
using TechademyEMS.Models.DesignationModel;
using TechademyEMS.Models.Employee_Model;


namespace TechademyEMS.Repository.Interface
{
    public interface IDesignationRepository
    {
        public List<Designation> GetAll();
        public Designation GetById(int id);
        public Designation Add(AddDesignationRequest des);
        public Designation Update(AddDesignationRequest des,int id);
        bool Delete(int id);
    }
}

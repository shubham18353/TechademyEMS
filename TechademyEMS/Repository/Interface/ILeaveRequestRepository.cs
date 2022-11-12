
using TechademyEMS.Models.LeaveRequest_Model;
using TechademyEMS.Models.LeaveRequestModel;

namespace TechademyEMS.Repository.Interface
{
    public interface ILeaveRequestRepository
    {
        public List<LeaveRequest> GetAll();
        public LeaveRequest GetById(int id);
        public LeaveRequest Add(AddLeaveRequest request);
        public LeaveRequest Update(AddLeaveRequest request,int id);
        bool Delete(int id);
    }
}

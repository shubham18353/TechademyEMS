using TechademyEMS.DatabaseContext;
using TechademyEMS.Models.LeaveRequest_Model;
using TechademyEMS.Models.LeaveRequestModel;
using TechademyEMS.Repository.Interface;

namespace TechademyEMS.Repository.Implementation
{
    public class LeaveRequestRepository:ILeaveRequestRepository
    {
        private readonly EMSDbContext _context;

        public LeaveRequestRepository(EMSDbContext context)
        {
            _context = context;
        }

        public LeaveRequest Add(AddLeaveRequest request)
        {
            try
            {
                LeaveRequest leaveRequest = new LeaveRequest();
                leaveRequest.LeaveType = request.LeaveType;
                leaveRequest.FromDate = request.FromDate;
                leaveRequest.ToDate = request.ToDate;
                leaveRequest.Status= request.Status;
                leaveRequest.Reason= request.Reason;
                _context.LeaveRequests.Add(leaveRequest);
                _context.SaveChangesAsync();
                return leaveRequest;
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
                var request = _context.LeaveRequests.FirstOrDefault(x => x.LeaveId == id);
                if (request != null)
                {
                    _context.LeaveRequests.Remove(request);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw new Exception("LeaveRequest can't be deleted");
            }
        }

        public List<LeaveRequest> GetAll()
        {
            try
            {
                List<LeaveRequest> requests = _context.LeaveRequests.ToList();
                return requests;
            }
            catch
            {
                throw new Exception("Server Error! Can't load Leave Requests");
            }
        }

        public LeaveRequest GetById(int id)
        {
            var request = _context.LeaveRequests.Find(id);
            if (request != null)
                return request;
            else
                throw new Exception("LeaveRequest Id mismatch!");
        }

        public LeaveRequest Update(AddLeaveRequest request, int id)
        {
            try
            {
                var leaveRequest = _context.LeaveRequests.Find(id);
                if (leaveRequest != null)
                {
                    leaveRequest.LeaveType = request.LeaveType;
                    leaveRequest.FromDate = request.FromDate;
                    leaveRequest.ToDate = request.ToDate;
                    leaveRequest.Status = request.Status;
                    leaveRequest.Reason = request.Reason;
                   
                    _context.SaveChangesAsync();
                    return leaveRequest;
                }
                else
                    throw new Exception("Leave Request Not Found!");
            }
            catch
            {
                throw;
            }
        }
    }
}

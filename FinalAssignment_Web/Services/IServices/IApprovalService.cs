using FinalAssignment_Model.Models;

namespace FinalAssignment_Web.Services.IServices
{
	public interface IApprovalService
	{
		Task<IEnumerable<Course>> GetUsersAsync();
		Task<bool> ApproveCourse(int id);
		Task<bool> RejectCourse(int id);
	}
}

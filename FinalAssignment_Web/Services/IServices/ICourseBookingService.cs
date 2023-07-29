using FinalAssignment_Model.Models;
using FinalAssignment_Model.Models.ModelDTO;

namespace FinalAssignment_Web.Services.IServices
{
    public interface ICourseBookingService
    {
        Task<IEnumerable<CourseBooking>> GetCourseBooking();
        Task<CourseBooking> GetIndividualCourseBooking(int id);
        Task<CourseBooking> CreateCourseBooking(CourseBookingDTO cb);

        Task DeleteCourseBooking(int id);
    }
}

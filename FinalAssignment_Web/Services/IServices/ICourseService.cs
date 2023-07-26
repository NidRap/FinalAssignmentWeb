using FinalAssignment_Model.Models;
using FinalAssignment_MOdels.Models;

namespace FinalAssignment_Web.Services.IServices
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetIndividual(int id);
        Task<Course> CreateCourse(CourseDTO createDTO);
        Task<Course> UpdateCourse(int id, Course course);
        Task RemoveCourse(int id);
    }
}

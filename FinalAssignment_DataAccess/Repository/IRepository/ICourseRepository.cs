
using FinalAssignment_Model.Models;

namespace FinalAssignment_DataAccess.Repository.IRepository
{
    public interface  ICourseRepository
    {
        List<Course> GetAllCourses();
        Course GetCourse(int Id);
        void CreateCourse(Course entity);
        void RemoveCourse(Course entity);

        void UpdateCourse(Course entity);
    }
}

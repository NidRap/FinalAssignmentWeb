
using System.Linq.Expressions;
using FinalAssignment_Model.Models;

namespace FinalAssignment_DataAccess.Repository.IRepository
{
    public interface  ICourseRepository<T> where T : class
	{
        List<Course> GetAllCourses(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Course GetCourse(int id);
        void CreateCourse(Course entity);
        void RemoveCourse(Course entity);

        void UpdateCourse(Course entity);
		//Course GetCourse(Func<object, bool> value);
	}
}

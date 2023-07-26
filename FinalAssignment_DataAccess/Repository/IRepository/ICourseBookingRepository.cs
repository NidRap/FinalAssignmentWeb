using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssignment_Model.Models;

namespace FinalAssignment_DataAccess.Repository.IRepository
{
	public interface ICourseBookingRepository
	{
		List<Course> GetAllCourses();
		Course GetCourse(int Id);
		void CreateCourse(Course entity);
		void RemoveCourse(Course entity);

		void UpdateCourse(Course entity);
	}
}

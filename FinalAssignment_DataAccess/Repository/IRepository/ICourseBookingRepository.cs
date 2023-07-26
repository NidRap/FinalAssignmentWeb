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
		List<CourseBooking> GetAllCourses();
		CourseBooking GetCourse(int Id);
		void CreateCourse(CourseBooking entity);
		void RemoveCourse(CourseBooking entity);

		void UpdateCourse(CourseBooking entity);
	}
}

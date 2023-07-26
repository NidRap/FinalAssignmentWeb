using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalAssignment_DataAccess.Data;
using FinalAssignment_DataAccess.Repository.IRepository;
using FinalAssignment_Model.Models;

namespace FinalAssignment_DataAccess.Repository
{
	public class CourseBookingRepository :ICourseBookingRepository
	{
		private readonly ApplicationDbContext _db;
		public CourseBookingRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public void CreateCourse(CourseBooking entity)
		{
			_db.CourseBooking.Add(entity);
			_db.SaveChanges();

		}

		public CourseBooking GetCourse(int Id)
		{


			return _db.CourseBooking.FirstOrDefault(u => u.Id == Id);



		}

		public List<CourseBooking> GetAllCourses()
		{
			return _db.CourseBooking.ToList();
		}

		public void RemoveCourse(CourseBooking entity)
		{
			_db.Remove(entity);
			_db.SaveChanges();
		}


		public void UpdateCourse(CourseBooking entity)
		{
			_db.Update(entity);
			_db.SaveChanges();
		}
	}
}


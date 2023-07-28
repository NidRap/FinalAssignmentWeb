using AutoMapper;
using FinalAssignment_DataAccess.Data;
using FinalAssignment_DataAccess.Repository.IRepository;
using FinalAssignment_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalAssignment_API.Controllers
{
	[Route("api/Admin/[action]")]
	[ApiController]
	
	public class AdminController : ControllerBase

	{
		private readonly ICourseRepository<Course> _courseRepository;
		private readonly ApplicationDbContext _dbContext;


		public AdminController(ICourseRepository<Course> courseRepository, ApplicationDbContext dbContext)
		{
			
			_courseRepository = courseRepository;
			_dbContext = dbContext;

		}
		[HttpGet]
		public IActionResult GetAllApprovalsRejections()
		{
			IEnumerable<Course> model = _courseRepository.GetAllCourses(u => u.IsApproved == false && u.IsRejected == false);
			if (model == null)
			{
				return NotFound();

			}
			else
			{
				return Ok(model);
			}

		}
		[HttpGet]
		public IActionResult ApproveCourse(int id)
		{
			if (id == 0)
			{
				return BadRequest();

			}

			//Course course = _courseRepository.GetCourse(u =>u.I == id);
			Course course = _courseRepository.GetCourse(id);

			if (course == null)
			{
				return NotFound();

			}
			course.IsApproved = true;
			_dbContext.SaveChanges();
			return Ok(course);
		}
		[HttpGet]
		public IActionResult RejectCourse(int id)
		{
			if (id == 0)
			{
				return BadRequest();

			}

			Course course = _courseRepository.GetCourse(id);
			if (course == null)
			{
				return NotFound();

			}
			course.IsRejected = true;
			_dbContext.SaveChanges();
			return Ok(course);
		}
	}
}

using System.Net;
using AutoMapper;
using Azure;
using FinalAssignment_DataAccess.Data;
using FinalAssignment_DataAccess.Repository;
using FinalAssignment_DataAccess.Repository.IRepository;
using FinalAssignment_Model.Models;
using FinalAssignment_Model.Models.ModelDTO;
using FinalAssignment_MOdels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssignment_API.Controllers
{
	[Route("api/CourseBooking")]
	[ApiController]
	public class CourseBookingController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICourseBookingRepository _courseBookingRepository;
		private readonly ICourseRepository<Course> _courseRepository;
		private readonly ApplicationDbContext _db;


        public CourseBookingController(IMapper mapper, ICourseBookingRepository courseBookingRepository,ICourseRepository<Course> courseRepository, ApplicationDbContext db)
		{
			_mapper = mapper;
			_courseBookingRepository = courseBookingRepository;
			_courseRepository = courseRepository;
			_db = db;


		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public IEnumerable<CourseBooking> Get()
		{
			return _courseBookingRepository.GetAllCourses().ToList();

		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<CourseBookingDTO> CreateCourse([FromBody] CourseBookingDTO courseBookingDTO)
		{
            var course = _db.Courses.FirstOrDefault(c => c.Id == courseBookingDTO.CourseId);
            if (course == null)
            {
             
                return NotFound();
            }


            if (course.AvailableSeats <= 0)
            {
               
                return BadRequest();
            }
            var courseBooking = new CourseBookingDTO
            {
                CourseId = courseBookingDTO.CourseId,
              


            };

            CourseBooking result = _mapper.Map<CourseBooking>(courseBooking);

            _courseBookingRepository.CreateCourse(result);
            course.AvailableSeats--;
            _courseRepository.UpdateCourse(course);


            _db.SaveChanges();


            return Ok();




		}
    //    [Authorize(Roles ="Admin")]
		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<CourseBooking> Remove(int id)
		{
            if (id == 0)
            {
                return BadRequest();
            }

            var booking = _courseBookingRepository.GetCourse(id);
            if (booking == null)
            {
               
                return NotFound();
            }


            _courseBookingRepository.RemoveCourse(booking);
            _db.SaveChanges();

            var course = _db.Courses.FirstOrDefault(u => u.Id == booking.CourseId);
            if (course != null)
            {
                course.AvailableSeats++;
                _courseRepository.UpdateCourse(course);
                _db.SaveChanges();

            }

            return Ok();

        }

		[HttpPut("{Id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<CourseBooking> update(int Id, [FromBody] CourseBookingDTO courseBookingDTO)
		{
			if (courseBookingDTO == null)
			{
				return BadRequest();
			}

			var model =
			_mapper.Map<CourseBooking>(courseBookingDTO);
			_courseBookingRepository.UpdateCourse(model);
			return Ok(model);

		}

        [HttpGet("{id:int}", Name = "GetIndividual")]

        [ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<CourseBooking> GetIndividual(int id)
		{
            if (id == 0)
            {

            
                return BadRequest();

            }

            var course = _courseBookingRepository.GetCourse(id);
            if (course == null)
            {
              
                return NotFound();


            }

        
            return Ok();
        }
           
}
	}


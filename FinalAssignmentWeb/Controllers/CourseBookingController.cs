using AutoMapper;
using FinalAssignment_DataAccess.Repository.IRepository;
using FinalAssignment_Model.Models;
using FinalAssignment_MOdels.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssignment_API.Controllers
{
	[Route("api/CourseBooking")]
	[ApiController]
	public class CourseBookingController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICourseBookingRepository _courseBookingRepository;


		public CourseBookingController(IMapper mapper, ICourseBookingRepository courseBookingRepository)
		{
			_mapper = mapper;
			_courseBookingRepository = courseBookingRepository;


		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public IEnumerable<Course> Get()
		{
			return _courseBookingRepository.GetAllCourses().ToList();

		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<CourseDTO> CreateCourse([FromBody] CourseDTO courseDTO)
		{
			if (courseDTO == null)
			{
				return BadRequest(courseDTO);
			}


			Course model = _mapper.Map<Course>(courseDTO);
			_courseBookingRepository.CreateCourse(model);


			return Ok();


		}
		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<Course> Remove(int id)
		{
			if (id == null)
			{
				return BadRequest();
			}


			Course model = _courseBookingRepository.GetCourse(id);
			_courseBookingRepository.RemoveCourse(model);
			return Ok(model);

		}

		[HttpPut("{Id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<Course> update(int Id, [FromBody] CourseDTO courseDTO)
		{
			if (courseDTO == null)
			{
				return BadRequest();
			}

			var model =
			_mapper.Map<Course>(courseDTO);
			_courseBookingRepository.UpdateCourse(model);
			return Ok(model);

		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<Course> GetIndividual(int id)
		{
			if (id == null)
			{
				return BadRequest();
			}


			Course model = _courseBookingRepository.GetCourse(id);

			return Ok(model);

		}

	}
}

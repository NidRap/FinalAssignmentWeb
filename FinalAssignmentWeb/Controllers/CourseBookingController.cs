using AutoMapper;
using FinalAssignment_DataAccess.Repository.IRepository;
using FinalAssignment_Model.Models;
using FinalAssignment_Model.Models.ModelDTO;
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

		public IEnumerable<CourseBooking> Get()
		{
			return _courseBookingRepository.GetAllCourses().ToList();

		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<CourseDTO> CreateCourse([FromBody] CourseBookingDTO courseBookingDTO)
		{
			if (courseBookingDTO == null)
			{
				return BadRequest(courseBookingDTO);
			}


			CourseBooking model = _mapper.Map<CourseBooking>(courseBookingDTO);
			_courseBookingRepository.CreateCourse(model);


			return Ok();


		}
		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<CourseBooking> Remove(int id)
		{
			if (id == null)
			{
				return BadRequest();
			}


			CourseBooking model = _courseBookingRepository.GetCourse(id);
			_courseBookingRepository.RemoveCourse(model);
			return Ok(model);

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

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<CourseBooking> GetIndividual(int id)
		{
			if (id == null)
			{
				return BadRequest();
			}


			CourseBooking model = _courseBookingRepository.GetCourse(id);

			return Ok(model);

		}

	}
}

﻿using AutoMapper;
using FinalAssignment_DataAccess.Data;
using FinalAssignment_DataAccess.Repository.IRepository;
using FinalAssignment_Model.Models;
using FinalAssignment_MOdels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssignmentWeb.Controllers
{
	[Route("api/Course")]

	[ApiController]
	

	public class CourseController : ControllerBase
	{


		private readonly IMapper _mapper;
		private readonly ICourseRepository<Course> _courseRepository;
	

		public CourseController(IMapper mapper, ICourseRepository<Course> courseRepository)
		{
			_mapper = mapper;
			_courseRepository = courseRepository;
		

		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public IEnumerable<Course> Get()
		{
			return _courseRepository.GetAll().ToList();

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
			_courseRepository.CreateCourse(model);


			return Created("","");


		}
//	[Authorize(Roles ="Admin")]
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


			Course model = _courseRepository.GetCourse(id);
			_courseRepository.RemoveCourse(model);
			return Ok(model);

		}

		[HttpPut("{Id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<Course> update(int Id, [FromBody] CourseDTO courseDTO)
		{
			if (courseDTO == null || Id != courseDTO.Id)
			{
				return BadRequest();
			}

			var model =
			_mapper.Map<Course>(courseDTO);
			_courseRepository.UpdateCourse(model);
			return Ok(courseDTO);

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


			Course model = _courseRepository.GetCourse(id);

			return Ok(model);

		}



		

	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment_Model.Models.ModelDTO
{
	public class CourseBookingDTO
	{
		[Key]

		public int Id { get; set; }
		[Display(Name = "Course Id")]
		public int CourseId { get; set; }

		[ForeignKey("Course")]
		public Course Course { get; set; }

		[Display(Name = "Course Name")]
		public string CourseName { get; set; }

		public string Email { get; set; }
	}
}

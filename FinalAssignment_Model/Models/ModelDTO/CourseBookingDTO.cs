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
		[ForeignKey("Course")]
		public int CourseId { get; set; }
		public string CourseName { get; set; }
	}
}

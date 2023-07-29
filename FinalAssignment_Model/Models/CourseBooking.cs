using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment_Model.Models
{
	public class CourseBooking
	{
		[Key]
		
		public int Id { get; set; }

		[Display(Name = "Course Id")]
		public int CourseId { get; set; }

		[ForeignKey("CourseId")]
		public Course Course { get; set; }

	
	}
}

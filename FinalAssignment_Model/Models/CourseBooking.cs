﻿using System;
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
		[ForeignKey("Course")]
		public int CourseId { get; set; }
		public string CourseName { get; set; }
	}
}

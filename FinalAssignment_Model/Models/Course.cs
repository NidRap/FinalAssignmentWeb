﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAssignment_Model.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Course Name is required")]
        [MaxLength(50, ErrorMessage = "Course Name cannot exceed 50 characters.")]
        [Display(Name = "Course Name")]
        public string courseName { get; set; }

        [Required(ErrorMessage = "Course Description is required.")]
        [MaxLength(100, ErrorMessage = "Course Description cannot exceed 100 characters.")]
        //[Column(TypeName = "varchar(100)")]
        [Display(Name = "Course Description")]
        public string courseDescription { get; set; }
        [Required(ErrorMessage = "Start Date is required.")]
        [Display(Name = "Start Date")]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is required.")]
        [Display(Name = "End Date")]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Available seats is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Available seats must be a positive number.")]
        [Display(Name = "Available Seats")]
        [Column(TypeName = "int")]
        public int AvailableSeats { get; set; }

        //public bool IsApproved { get; set; }
        //public bool IsRejected { get; set; }

    }
}


using FinalAssignment_Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalAssignment_DataAccess.Data
{
    public class ApplicationDbContext :IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        

        }
        public DbSet<Course> Courses { get; set; }
		public DbSet<CourseBooking> CourseBooking { get; set; }
		public DbSet<ApplicationUser> ApplicationUser { get; set; }


	}
}

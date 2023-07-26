
using FinalAssignment_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAssignment_DataAccess.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        

        }
        public DbSet<Course> Courses { get; set; }
    }
}

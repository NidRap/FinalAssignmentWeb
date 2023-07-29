using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalAssignment_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatedCourseBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "CourseBooking");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CourseBooking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "CourseBooking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CourseBooking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

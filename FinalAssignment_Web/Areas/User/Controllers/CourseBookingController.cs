using FinalAssignment_Model.Models.ModelDTO;
using FinalAssignment_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssignment_Web.Areas.User.Controllers
{
    [Area("User")]
    public class CourseBookingController : Controller
    {
        private readonly ICourseBookingService _courseBookingService;
        private readonly ICourseService _courseService;
        private readonly IApprovalService _approvalService;
        private readonly IHttpContextAccessor _contextAccessor;



        public CourseBookingController(ICourseBookingService courseBookingService, ICourseService courseService, IHttpContextAccessor contextAccessor, IApprovalService approvalService)
        {

            _courseBookingService = courseBookingService;
            _courseService = courseService;
            _contextAccessor = contextAccessor;
            _approvalService = approvalService;
        }


        public async Task<IActionResult> Index()
        {
            var course = await _courseBookingService.GetCourseBooking();

            var booking = _courseService.GetAll();

            ViewBag.booking = booking;


            return View(course);
        }

        public async Task<IActionResult> CreateBooking()
        {
           
            return View();
        }

      

        [HttpPost]
        public async Task<IActionResult> CreateBooking(int courseId)
        {
            var course = await _courseService.GetIndividual(courseId);
            CourseBookingDTO booking = new CourseBookingDTO
            {
                CourseId = courseId,


            };


            await _courseBookingService.CreateCourseBooking(booking);
            TempData["Success"] = "Enrollment Done Successfully";
            return RedirectToAction(nameof(Index));



        }





        public async Task<IActionResult> DeleteCourseBooking(int id)
        {
            var booking = await _courseService.GetIndividual(id);
            return View(booking);
        }

        [HttpPost]
        [ActionName("DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _courseBookingService.DeleteCourseBooking(id);
            TempData["success"] = "Course UnEnrolled Successfully";

            return RedirectToAction(nameof(Index));
        }

    }
}

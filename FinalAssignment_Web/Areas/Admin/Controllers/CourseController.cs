using FinalAssignment_Model.Models;
using FinalAssignment_MOdels.Models;
using FinalAssignment_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssignment_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {


        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {

            _courseService = courseService;
        }


        public async Task<IActionResult> Index()
        {

            var model = await _courseService.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseDTO courseDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _courseService.CreateCourse(courseDTO);
                TempData["success"] = "Course Created Successfully";
                return RedirectToAction(nameof(Index), new { id = result.Id });
            }
          
            return View(courseDTO);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetIndividual(id);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Course course)
        {
            if (ModelState.IsValid)
            {
                await _courseService.UpdateCourse(id, course);
                TempData["success"] = "Course Updated Successfully";
                return RedirectToAction(nameof(Index), new { id });
            }

            return View(course);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetIndividual(id);
            return View(course);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.RemoveCourse(id);
            TempData["success"] = "Course Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }


    }
}

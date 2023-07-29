using FinalAssignment_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssignment_Web.Areas.Admin.Controllers
{
	[Area("Admin")]

	[Authorize(Roles ="Admin")]
	public class ApprovalController : Controller
	{
		private readonly IApprovalService _approvalService;

		public ApprovalController(IApprovalService approvalService)
		{
			_approvalService = approvalService;
		}

		public async Task<IActionResult> Index()
		{
			var model = await _approvalService.GetUsersAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> ApprovedCourse(int id)
		{
			try
			{
				await _approvalService.ApproveCourse(id);
				TempData["Success"] = "Approved";
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View("Index");
			}
		}

		[HttpPost]
		public async Task<IActionResult> RejectCourse(int id)
		{
			try
			{
				await _approvalService.RejectCourse(id);
				TempData["Success"] = "Rejected Successfully";
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View("Index");
			}
		}
	}
}


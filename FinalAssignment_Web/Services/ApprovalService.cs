using FinalAssignment_Model.Models;
using FinalAssignment_MOdels.Models;
using FinalAssignment_Web.Services.IServices;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace FinalAssignment_Web.Services
{

	public class ApprovalService:IApprovalService

	{
		private readonly HttpClient _httpClient;
		private const string BaseUrl = "http://localhost:5242";

		public ApprovalService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri(BaseUrl);
			
		}
		public async Task<IEnumerable<Course>> GetUsersAsync()
		{
			HttpResponseMessage response = await _httpClient.GetAsync("/api/Admin/GetAllApprovalsRejections");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			IEnumerable<Course> course = JsonConvert.DeserializeObject<IEnumerable<Course>>(content);
			return course;
		}

		public async Task<bool> ApproveCourse(int id)
		{
			var response = await _httpClient.GetAsync($"api/Admin/ApproveCourse?id={id}");
			if (response.IsSuccessStatusCode)
			{
				return true;
			}
			else if (response.StatusCode == HttpStatusCode.NotFound)
			{
				throw new Exception("Course not found.");
			}
			else
			{
				throw new Exception("Error while approving Course.");
			}
		}

		public async Task<bool> RejectCourse(int id)
		{
			var response = await _httpClient.GetAsync($"api/Admin/RejectCourse?id={id}");
			if (response.IsSuccessStatusCode)
			{
				return true;
			}
			else if (response.StatusCode == HttpStatusCode.NotFound)
			{
				throw new Exception("Course not found.");
			}
			else
			{
				throw new Exception("Error while rejecting Course.");
			}

		}

	}
}

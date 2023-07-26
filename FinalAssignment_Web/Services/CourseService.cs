using Azure;
using FinalAssignment_DataAccess.Data;
using FinalAssignment_Model.Models;
using FinalAssignment_MOdels.Models;
using FinalAssignment_Web.Services.IServices;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;

namespace FinalAssignment_Web.Services
{
	public class CourseService : ICourseService
	{

		private readonly HttpClient _httpClient;
		private const string Baseurl = "http://localhost:5242";
		public CourseService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri(Baseurl);

		}




		public async Task<IEnumerable<Course>> GetAll()
		{

			HttpResponseMessage response = await _httpClient.GetAsync("/api/Course/");
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			IEnumerable<Course> blog = JsonConvert.DeserializeObject<IEnumerable<Course>>(content);
			return blog;

		}




		public async Task<Course> GetIndividual(int Id)
		{

			HttpResponseMessage response = await _httpClient.GetAsync($"/api/Course/{Id}");
			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				return null;
			}
			response.EnsureSuccessStatusCode();
			string content = await response.Content.ReadAsStringAsync();
			Course model = JsonConvert.DeserializeObject<Course>(content);
			return model;
		}

		public async Task<Course> CreateCourse(CourseDTO course)
		{

			string json = JsonConvert.SerializeObject(course);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");


			HttpResponseMessage response = await _httpClient.PostAsync("/api/Course/", content);
			response.EnsureSuccessStatusCode();
			string responseContent = await response.Content.ReadAsStringAsync();
			Course model = JsonConvert.DeserializeObject<Course>(responseContent);
			return model;
		}

		public async Task<Course> UpdateCourse(int id, Course course)
		{
			string json = JsonConvert.SerializeObject(course);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

			HttpResponseMessage response = await _httpClient.PutAsync($"/api/Course/{id}", content);
			response.EnsureSuccessStatusCode();
			string responseContent = await response.Content.ReadAsStringAsync();
			Course model = JsonConvert.DeserializeObject<Course>(responseContent);
			return model;
		}

		public async Task RemoveCourse(int id)
		{
			HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/Course/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}
 

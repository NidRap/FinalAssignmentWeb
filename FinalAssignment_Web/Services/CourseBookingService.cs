using System.Net;
using System.Text;
using FinalAssignment_Model.Models;
using FinalAssignment_Model.Models.ModelDTO;
using FinalAssignment_Web.Services.IServices;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace FinalAssignment_Web.Services
{
    public class CourseBookingService : ICourseBookingService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:5242";

        public CourseBookingService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);

        }

        public async Task<CourseBooking> CreateCourseBooking(CourseBookingDTO cb)
        {
            string json = JsonConvert.SerializeObject(cb);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/api/CourseBooking/", content);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            CourseBooking courseBooking = JsonConvert.DeserializeObject<CourseBooking>(responseContent);
            return courseBooking;

        }

        public  async Task DeleteCourseBooking(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/CourseBooking/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<CourseBooking>> GetCourseBooking()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/CourseBooking");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<CourseBooking> cb = JsonConvert.DeserializeObject<IEnumerable<CourseBooking>>(content);
            return cb;
        }

        public async Task<CourseBooking> GetIndividualCourseBooking(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/CourseBooking/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            CourseBooking cb = JsonConvert.DeserializeObject<CourseBooking>(content);
            return cb;
        }
    }
}

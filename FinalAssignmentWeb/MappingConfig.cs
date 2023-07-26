using AutoMapper;
using FinalAssignment_Model.Models;
using FinalAssignment_MOdels.Models;

namespace FinalAssignmentWeb
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Course,CourseDTO>().ReverseMap();
            
        }
    }
}

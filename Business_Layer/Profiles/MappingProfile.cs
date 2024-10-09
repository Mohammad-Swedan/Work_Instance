using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Profiles
{
    using AutoMapper;
    using DataAccess_Layer.DTOs;
    using DataAccess_Layer.Models;

    namespace YourProject.BLL.Profiles
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Student, StudentDto>().ReverseMap();
                CreateMap<Doctor, DoctorDto>().ReverseMap();
                CreateMap<Course, CourseDto>().ReverseMap();
                CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            }
        }
    }

}

using AutoMapper;
using Business_Layer.ServiceInterfaces;
using DataAccess_Layer.DTOs;
using DataAccess_Layer.Models;
using DataAccess_Layer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepo _courseRepo;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepo courseRepository, IMapper mapper)
        {
            _courseRepo = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await _courseRepo.GetByIdAsync(id);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var courses = await _courseRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task AddAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _courseRepo.AddAsync(course);
        }

        public async Task UpdateAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _courseRepo.UpdateAsync(course);
        }

        public async Task DeleteAsync(int id)
        {
            await _courseRepo.DeleteAsync(id);
        }
    }
}

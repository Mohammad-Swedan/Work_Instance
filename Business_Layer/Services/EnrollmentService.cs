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
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepo _enrollmentRepo;
        private readonly IMapper _mapper;

        public EnrollmentService(IEnrollmentRepo enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepo = enrollmentRepository;
            _mapper = mapper;
        }

        public async Task<EnrollmentDto> GetByIdAsync(int id)
        {
            var enrollment = await _enrollmentRepo.GetByIdAsync(id);
            return _mapper.Map<EnrollmentDto>(enrollment);
        }

        public async Task<IEnumerable<EnrollmentDto>> GetAllAsync()
        {
            var enrollments = await _enrollmentRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
        }

        public async Task AddAsync(EnrollmentDto enrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            await _enrollmentRepo.AddAsync(enrollment);
        }

        public async Task UpdateAsync(EnrollmentDto enrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            await _enrollmentRepo.UpdateAsync(enrollment);
        }

        public async Task DeleteAsync(int id)
        {
            await _enrollmentRepo.DeleteAsync(id);
        }
    }
}

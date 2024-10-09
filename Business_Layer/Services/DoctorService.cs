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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepo doctorRepository, IMapper mapper)
        {
            _doctorRepo = doctorRepository;
            _mapper = mapper;
        }

        public async Task<DoctorDto> GetByIdAsync(int id)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);
            return _mapper.Map<DoctorDto>(doctor);
        }

        public async Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            var doctors = await _doctorRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        }

        public async Task AddAsync(DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepo.AddAsync(doctor);
        }

        public async Task UpdateAsync(DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepo.UpdateAsync(doctor);
        }

        public async Task DeleteAsync(int id)
        {
            await _doctorRepo.DeleteAsync(id);
        }
    }
}

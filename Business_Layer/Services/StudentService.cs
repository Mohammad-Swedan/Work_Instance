using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business_Layer.ServiceInterfaces;
using DataAccess_Layer.DTOs;
using DataAccess_Layer.Models;
using DataAccess_Layer.RepositoryInterfaces;

namespace Business_Layer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepo studentRepository, IMapper mapper)
        {
            _studentRepo = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await _studentRepo.GetByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task AddAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentRepo.AddAsync(student);
        }

        public async Task UpdateAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            await _studentRepo.UpdateAsync(student);
        }

        public async Task DeleteAsync(int id)
        {
            await _studentRepo.DeleteAsync(id);
        }
    }
}

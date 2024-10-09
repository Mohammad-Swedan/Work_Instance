using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer.DTOs;


namespace Business_Layer.ServiceInterfaces
{
    public interface IStudentService
    {
        Task<StudentDto> GetByIdAsync(int id);

        Task<IEnumerable<StudentDto>> GetAllAsync();

        Task AddAsync(StudentDto studentDto);

        Task UpdateAsync(StudentDto studentDto);

        Task DeleteAsync(int id);
    }
}

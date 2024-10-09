using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer.DTOs;


namespace Business_Layer.ServiceInterfaces
{
    public interface ICourseService
    {
        Task<CourseDto> GetByIdAsync(int id);

        Task<IEnumerable<CourseDto>> GetAllAsync();

        Task AddAsync(CourseDto courseDto);

        Task UpdateAsync(CourseDto courseDto);

        Task DeleteAsync(int id);
    }
}

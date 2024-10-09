using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer;
using DataAccess_Layer.DTOs;

namespace Business_Layer.ServiceInterfaces
{
    public interface IEnrollmentService
    {
        Task<EnrollmentDto> GetByIdAsync(int id);

        Task<IEnumerable<EnrollmentDto>> GetAllAsync();

        Task AddAsync(EnrollmentDto enrollmentDto);

        Task UpdateAsync(EnrollmentDto enrollmentDto);

        Task DeleteAsync(int id);
    }
}

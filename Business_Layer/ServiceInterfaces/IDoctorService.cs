using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess_Layer.DTOs;


namespace Business_Layer.ServiceInterfaces
{
    public interface IDoctorService
    {
        Task<DoctorDto> GetByIdAsync(int id);

        Task<IEnumerable<DoctorDto>> GetAllAsync();

        Task AddAsync(DoctorDto doctorDto);

        Task UpdateAsync(DoctorDto doctorDto);

        Task DeleteAsync(int id);
    }
}

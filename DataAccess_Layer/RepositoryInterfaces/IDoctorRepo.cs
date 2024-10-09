using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.RepositoryInterfaces
{
    public interface IDoctorRepo
    {
        Task<Doctor> GetByIdAsync(int id);

        Task<IEnumerable<Doctor>> GetAllAsync();

        Task AddAsync(Doctor doctor);

        Task UpdateAsync(Doctor doctor);

        Task DeleteAsync(int id);
    }
}

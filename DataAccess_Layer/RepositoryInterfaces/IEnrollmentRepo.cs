using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.RepositoryInterfaces
{
    public interface IEnrollmentRepo
    {
        Task<Enrollment> GetByIdAsync(int id);

        Task<IEnumerable<Enrollment>> GetAllAsync();

        Task AddAsync(Enrollment enrollment);

        Task UpdateAsync(Enrollment enrollment);

        Task DeleteAsync(int id);
    }
}

using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.RepositoryInterfaces
{
    public interface ICourseRepo
    {
        Task<Course> GetByIdAsync(int id);

        Task<IEnumerable<Course>> GetAllAsync();

        Task AddAsync(Course course);

        Task UpdateAsync(Course course);

        Task DeleteAsync(int id);
    }
}

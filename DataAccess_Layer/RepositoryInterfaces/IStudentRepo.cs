using DataAccess_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.RepositoryInterfaces
{
    public interface IStudentRepo
    {
        Task<Student> GetByIdAsync(int id);

        Task<IEnumerable<Student>> GetAllAsync();

        Task AddAsync(Student student);

        Task UpdateAsync(Student student);

        Task DeleteAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public int Credits { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

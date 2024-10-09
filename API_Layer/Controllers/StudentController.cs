using Business_Layer.ServiceInterfaces;
using DataAccess_Layer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.EmailService.Interfaces;
using Service_Layer.EmailService.Models;
using Service_Layer.ImageService;

namespace API_Layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IEmailService _emailService;
        private readonly IImageService  _imageService;

        public StudentController(IStudentService studentService, IEmailService emailService,IImageService imageService)
        {
            _studentService = studentService;
            _emailService = emailService;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> PostStudent(StudentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _studentService.AddAsync(studentDto);

            await _emailService.SendEmailAsync(new EmailMessage
            {
                To = studentDto.Email,
                Subject = "Welcome",
                Body = $"Hello {studentDto.Name}, welcome to our university!"
            });

            return CreatedAtAction(nameof(GetStudent), new { id = studentDto.StudentId }, studentDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentDto studentDto)
        {
            if (id != studentDto.StudentId)
            {
                return BadRequest();
            }

            await _studentService.UpdateAsync(studentDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                await _imageService.SaveImageAsync(file);
                return Ok(new { fileName = file.FileName });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log exception (omitted for brevity)
                return StatusCode(500, "Internal server error / " + ex.Message);
            }
        }
    }
}

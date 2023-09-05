using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository repo)
        {
            _studentRepo = repo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                return Ok(await _studentRepo.GetAllStudentAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        [Authorize]
        public async Task<IActionResult> GetStudentsById(int id)
        {
            var student = await _studentRepo.GetStudentByIdAsync(id);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewStudents(Student student)
        {
            try
            {
                var newid = await _studentRepo.AddStudentAsync(student);
                var std = await _studentRepo.GetStudentByIdAsync(newid);
                return std == null ? NotFound() : Ok(std);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        [Authorize]
        public async Task<IActionResult> UpdateStudents(int Id, Student student)
        {
            await _studentRepo.UpdateStudentByIdAsync(Id, student);
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteStudents(int Id)
        {
            await _studentRepo.DeleteStudentAsync(Id);
            return Ok();
        }
    }
}

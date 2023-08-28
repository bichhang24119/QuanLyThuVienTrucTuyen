using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepo;

        public TeacherController(ITeacherRepository repo)
        {
            _teacherRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                return Ok(await _teacherRepo.GetAllTeacherAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTeachersById(int id)
        {
            var teacher = await _teacherRepo.GetTeacherByIdAsync(id);
            return teacher == null ? NotFound() : Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTeachers(Teacher teacher)
        {
            try
            {
                var newid = await _teacherRepo.AddTeacherAsync(teacher);
                var tea = await _teacherRepo.GetTeacherByIdAsync(newid);
                return tea == null ? NotFound() : Ok(tea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateTeachers(int Id, Teacher teacher)
        {
            await _teacherRepo.UpdateTeacherByIdAsync(Id, teacher);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTeachers(int Id)
        {
            await _teacherRepo.DeleteTeacherAsync(Id);
            return Ok();
        }
    }
}

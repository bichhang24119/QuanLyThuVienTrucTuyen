using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamBankController : ControllerBase
    {
        private readonly IExamBankRepository _exambankRepo;

        public ExamBankController(IExamBankRepository repo)
        {
            _exambankRepo = repo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                return Ok(await _exambankRepo.GetAllExamBankAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        [Authorize]
        public async Task<IActionResult> GetTeachersById(int id)
        {
            var exambank = await _exambankRepo.GetExamBankByIdAsync(id);
            return exambank == null ? NotFound() : Ok(exambank);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewTeachers(ExamBank exambank)
        {
            try
            {
                var newid = await _exambankRepo.AddExamBankAsync(exambank);
                var exb = await _exambankRepo.GetExamBankByIdAsync(newid);
                return exb == null ? NotFound() : Ok(exb);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTeachers(int Id, ExamBank exambank)
        {
            await _exambankRepo.UpdateExamBankByIdAsync(Id, exambank);
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTeachers(int Id)
        {
            await _exambankRepo.DeleteExamBankAsync(Id);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateFileController : ControllerBase
    {
        private readonly IPrivateFileRepository _privatefileRepo;

        public PrivateFileController(IPrivateFileRepository repo)
        {
            _privatefileRepo = repo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPrivateFiles()
        {
            try
            {
                return Ok(await _privatefileRepo.GetAllPrivateFileAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        [Authorize]
        public async Task<IActionResult> GetPrivateFilesById(int id)
        {
            var privatefile = await _privatefileRepo.GetPrivateFileByIdAsync(id);
            return privatefile == null ? NotFound() : Ok(privatefile);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewPrivateFiles(PrivateFile privatefile)
        {
            try
            {
                var newid = await _privatefileRepo.AddPrivateFileAsync(privatefile);
                var prf = await _privatefileRepo.GetPrivateFileByIdAsync(newid);
                return prf == null ? NotFound() : Ok(prf);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePrivateFiles(int Id, PrivateFile privatefile)
        {
            await _privatefileRepo.UpdatePrivateFileByIdAsync(Id, privatefile);
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<IActionResult> DeletePrivateFiles(int Id)
        {
            await _privatefileRepo.DeletePrivateFileAsync(Id);
            return Ok();
        }
    }
}

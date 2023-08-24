using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepo;

        public DocumentController(IDocumentRepository repo) 
        { 
            _documentRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocuments()
        {
            try
            {
                return Ok(await _documentRepo.GetAllDocumentAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDocumentById( int id)
        {
            var document = await _documentRepo.GetDocumentByIdAsync(id);
            return document ==null ? NotFound() : Ok(document);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetDocumentByName(string name)
        {
            var document = await _documentRepo.GetDocumentByNameAsync(name);
            return document == null ? NotFound() : Ok(document);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDocument(Document document)
        {
            try
            {
                var newid = await _documentRepo.AddDocumentAsync(document);
                var docum = await _documentRepo.GetDocumentByIdAsync(newid);
                return docum == null ? NotFound() : Ok(docum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateDocument(int Id, Document document)
        {
            await _documentRepo.UpdateDocumentByIdAsync(Id, document);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDocument(int Id)
        {
            await _documentRepo.DeleteDocumentAsync(Id);
            return Ok();
        }
    }
}

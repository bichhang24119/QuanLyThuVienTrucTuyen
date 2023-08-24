using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Helpers
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DocumentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddDocumentAsync(Document document)
        {
            var add = _mapper.Map<Document>(document);
            _context.Documents!.Add(add);
            await _context.SaveChangesAsync();

            return add.Id;
        }

        public async Task DeleteDocumentAsync(int Id)
        {
            var delete = _context.Documents!.SingleOrDefault(b => b.Id == Id);
            if (delete != null)
            {
                _context.Documents!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Document>> GetAllDocumentAsync()
        {
            var documents = await _context.Documents!.ToListAsync();
            return _mapper.Map<List<Document>>(documents);
        }

        public async Task<Document> GetDocumentByIdAsync(int Id)
        {
            var id = await _context.Documents!.FindAsync(Id);
            return _mapper.Map<Document>(id);
        }

        public async Task<Document> GetDocumentByNameAsync(string Name)
        {
            var name = await _context.Documents!.FindAsync(Name);
            return _mapper.Map<Document>(name);
        }

        public async Task UpdateDocumentByIdAsync(int Id, Document document)
        {
            if (Id == document.Id)
            {
                var update = _mapper.Map<Document>(document);
                _context.Documents!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using QuanLyThuVien.Data;

namespace QuanLyThuVien.Repositories
{
    public interface IDocumentRepository
    {
        public Task<List<Document>> GetAllDocumentAsync();
        public Task<Document> GetDocumentByNameAsync(String Name);
        public Task<Document> GetDocumentByIdAsync(int Id);
        public Task<int> AddDocumentAsync(Document document);
        public Task UpdateDocumentByIdAsync(int Id, Document document);
        public Task DeleteDocumentAsync(int Id);
    }
}

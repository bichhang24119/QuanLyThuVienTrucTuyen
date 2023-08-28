using QuanLyThuVien.Data;

namespace QuanLyThuVien.Repositories
{
    public interface IPrivateFileRepository
    {
        public Task<List<PrivateFile>> GetAllPrivateFileAsync();
        public Task<PrivateFile> GetPrivateFileByIdAsync(int Id);
        public Task<int> AddPrivateFileAsync(PrivateFile privatefile);
        public Task UpdatePrivateFileByIdAsync(int Id, PrivateFile privatefile);
        public Task DeletePrivateFileAsync(int Id);
    }
}

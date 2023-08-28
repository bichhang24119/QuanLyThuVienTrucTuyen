using QuanLyThuVien.Data;

namespace QuanLyThuVien.Repositories
{
    public interface IExamBankRepository
    {
        public Task<List<ExamBank>> GetAllExamBankAsync();
        public Task<ExamBank> GetExamBankByIdAsync(int Id);
        public Task<int> AddExamBankAsync(ExamBank exambank);
        public Task UpdateExamBankByIdAsync(int Id, ExamBank exambank);
        public Task DeleteExamBankAsync(int Id);
    }
}

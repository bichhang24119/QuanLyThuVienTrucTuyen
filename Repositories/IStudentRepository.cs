using QuanLyThuVien.Data;

namespace QuanLyThuVien.Repositories
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetAllStudentAsync();
        public Task<Student> GetStudentByIdAsync(int Id);
        public Task<int> AddStudentAsync(Student student);
        public Task UpdateStudentByIdAsync(int Id, Student student);
        public Task DeleteStudentAsync(int Id);
    }
}

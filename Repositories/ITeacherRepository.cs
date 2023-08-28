using QuanLyThuVien.Data;

namespace QuanLyThuVien.Repositories
{
    public interface ITeacherRepository
    {
        public Task<List<Teacher>> GetAllTeacherAsync();
        public Task<Teacher> GetTeacherByIdAsync(int Id);
        public Task<int> AddTeacherAsync(Teacher teacher);
        public Task UpdateTeacherByIdAsync(int Id, Teacher teacher);
        public Task DeleteTeacherAsync(int Id);
    }
}

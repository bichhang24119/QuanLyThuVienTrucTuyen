using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Helpers
{
    public class TeacherReposotory : ITeacherRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TeacherReposotory(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddTeacherAsync(Teacher teacher)
        {
            var add = _mapper.Map<Teacher>(teacher);
            _context.Teachers!.Add(add);
            await _context.SaveChangesAsync();

            return add.Id;
        }

        public async Task DeleteTeacherAsync(int Id)
        {
            var delete = _context.Teachers!.SingleOrDefault(b => b.Id == Id);
            if (delete != null)
            {
                _context.Teachers!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Teacher>> GetAllTeacherAsync()
        {
            var teachers = await _context.Teachers!.ToListAsync();
            return _mapper.Map<List<Teacher>>(teachers);
        }

        public async Task<Teacher> GetTeacherByIdAsync(int Id)
        {
            var id = await _context.Teachers!.FindAsync(Id);
            return _mapper.Map<Teacher>(id);
        }

        public async Task UpdateTeacherByIdAsync(int Id, Teacher teacher)
        {
            if (Id == teacher.Id)
            {
                var update = _mapper.Map<Teacher>(teacher);
                _context.Teachers!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}

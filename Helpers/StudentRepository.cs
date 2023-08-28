using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Helpers
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddStudentAsync(Student student)
        {
            var add = _mapper.Map<Student>(student);
            _context.Students!.Add(add);
            await _context.SaveChangesAsync();

            return add.Id;
        }

        public async Task DeleteStudentAsync(int Id)
        {
            var delete = _context.Students!.SingleOrDefault(b => b.Id == Id);
            if (delete != null)
            {
                _context.Students!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            var students = await _context.Students!.ToListAsync();
            return _mapper.Map<List<Student>>(students);
        }

        public async Task<Student> GetStudentByIdAsync(int Id)
        {
            var id = await _context.Students!.FindAsync(Id);
            return _mapper.Map<Student>(id);
        }

        public async Task UpdateStudentByIdAsync(int Id, Student student)
        {
            if (Id == student.Id)
            {
                var update = _mapper.Map<Student>(student);
                _context.Students!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}

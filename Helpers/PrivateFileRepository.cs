using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Helpers
{
    public class PrivateFileRepository : IPrivateFileRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PrivateFileRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddPrivateFileAsync(PrivateFile privatefile)
        {
            var add = _mapper.Map<PrivateFile>(privatefile);
            _context.PrivateFiles!.Add(add);
            await _context.SaveChangesAsync();

            return add.Id;
        }

        public async Task DeletePrivateFileAsync(int Id)
        {
            var delete = _context.PrivateFiles!.SingleOrDefault(b => b.Id == Id);
            if (delete != null)
            {
                _context.PrivateFiles!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<PrivateFile>> GetAllPrivateFileAsync()
        {
            var privatefile = await _context.PrivateFiles!.ToListAsync();
            return _mapper.Map<List<PrivateFile>>(privatefile);
        }

        public async Task<PrivateFile> GetPrivateFileByIdAsync(int Id)
        {
            var id = await _context.PrivateFiles!.FindAsync(Id);
            return _mapper.Map<PrivateFile>(id);
        }

        public async Task UpdatePrivateFileByIdAsync(int Id, PrivateFile privatefile)
        {
            if (Id == privatefile.Id)
            {
                var update = _mapper.Map<PrivateFile>(privatefile);
                _context.PrivateFiles!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}

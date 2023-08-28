using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.Data;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.Helpers
{
    public class ExamBankRepository : IExamBankRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ExamBankRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddExamBankAsync(ExamBank exambank)
        {
            var add = _mapper.Map<ExamBank>(exambank);
            _context.ExamBanks!.Add(add);
            await _context.SaveChangesAsync();

            return add.Id;
        }

        public async Task DeleteExamBankAsync(int Id)
        {
            var delete = _context.ExamBanks!.SingleOrDefault(b => b.Id == Id);
            if (delete != null)
            {
                _context.ExamBanks!.Remove(delete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ExamBank>> GetAllExamBankAsync()
        {
            var exambanks = await _context.ExamBanks!.ToListAsync();
            return _mapper.Map<List<ExamBank>>(exambanks);
        }

        public async Task<ExamBank> GetExamBankByIdAsync(int Id)
        {
            var id = await _context.ExamBanks!.FindAsync(Id);
            return _mapper.Map<ExamBank>(id);
        }

        public async Task UpdateExamBankByIdAsync(int Id, ExamBank exambank)
        {
            if (Id == exambank.Id)
            {
                var update = _mapper.Map<ExamBank>(exambank);
                _context.ExamBanks!.Update(update);
                await _context.SaveChangesAsync();
            }
        }
    }
}

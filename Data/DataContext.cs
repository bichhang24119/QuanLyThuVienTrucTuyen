using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuanLyThuVien.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }

        #region DbSet
        public DbSet<Document>? Documents { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<PrivateFile>? PrivateFiles { get; set; }
        public DbSet<ExamBank>? ExamBanks { get; set; }
        #endregion 
    }
}

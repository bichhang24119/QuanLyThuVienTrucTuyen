using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuanLyThuVien.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> otp) : base(otp) 
        { 
        }

        public DbSet<Document>? Documents { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace QuanLyThuVien.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
    }
}

using Microsoft.AspNetCore.Identity;
using QuanLyThuVien.Model;

namespace QuanLyThuVien.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}

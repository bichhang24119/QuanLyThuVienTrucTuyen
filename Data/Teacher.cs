using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien.Data
{
    [Table ("Teachers")]
    public class Teacher
    {
        [Key] public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Address { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        public string? Subject { get; set;}
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien.Data
{
    [Table ("PrivateFiles")]
    public class PrivateFile
    {
        [Key] public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }

    }
}

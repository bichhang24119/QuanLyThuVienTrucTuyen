using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien.Data
{
    [Table ("ExamBanks")]
    public class ExamBank
    {
        [Key] public int Id { get; set; }
        public string? Topic { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? Author { get; set; }
    }
}

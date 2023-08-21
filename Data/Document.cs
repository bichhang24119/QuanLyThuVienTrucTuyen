using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien.Data
{
    [Table ("Document")]
    public class Document
    {
        [Key] public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

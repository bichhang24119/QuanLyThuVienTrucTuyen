﻿using System.ComponentModel.DataAnnotations;

namespace QuanLyThuVien.Model
{
    public class SignUpModel
    {
        [Required]
        public string FullName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}

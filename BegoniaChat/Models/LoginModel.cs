using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BegoniaChat.Models
{
    public class LoginModel
    {
        [MaxLength(50), Required]
        public string Account { get; set; }

        [MaxLength(50), Required]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="請確認與輸入密碼相同。")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        [MaxLength(20), Required]
        public string FullName { get; set; }

        public bool IsRemember { get; set; }

    }
}
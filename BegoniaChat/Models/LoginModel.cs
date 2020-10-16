using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BegoniaChat.Models
{
    public class LoginModel
    {
        public ObjectId _id { get; set; }

        [MaxLength(50), Required]
        public string acc { get; set; }

        [MaxLength(50), Required]
        public string pswd { get; set; }

        [Compare("pswd",ErrorMessage ="請確認與輸入密碼相同。")]
        public string ConfirmPassword { get; set; }

        public string email { get; set; }

        public string gender { get; set; }

        [MaxLength(20), Required]
        public string name { get; set; }

        public bool IsRemember { get; set; }

    }
}
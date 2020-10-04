using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Personal_Website.Data.Models {
    public class AuthModel {

        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Display(Name = "Two-Factor Code:")]
        public string Code { get; set; }

        public bool PasswordVerified = false;
        public void Reset()
        {
            PasswordVerified = false;
            Password = string.Empty;
            Code = string.Empty;
        }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Personal_Website.Data.Models {
    public class AuthModel {

        [Display(Name = "Enter 2FA Code:")]
        public string Code { get; set; }

    }
}

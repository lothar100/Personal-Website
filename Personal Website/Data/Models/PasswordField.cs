using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Personal_Website.Data.Models {
    public class PasswordField {

        [Required]
        [Description("Enter Admin Password:")]
        [Display(Name = "Enter Admin Password:")]
        [PasswordPropertyText]
        public string Password { get; set; }

    }
}

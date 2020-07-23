using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Personal_Website.Data.Models {
    public class AdminModel {

        [Display(Name = "Enter Admin Password:")]
        public string Password { get; set; }

    }
}

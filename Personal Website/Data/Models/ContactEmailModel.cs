using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Website.Data.Models {
    public class ContactEmailModel {

        [Required]
        [Display(Name = " Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = " Email")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = " Message")]
        public string Message { get; set; }

        public string RemoteIPAddress { get; set; }
    }
}

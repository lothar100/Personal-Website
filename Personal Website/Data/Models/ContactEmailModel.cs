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
        [Display(Name = " Email")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = " Message")]
        public string Message {
            get => _message;

            set {
                _message = value;
                ResizeMessageRows(value);
            }
        }

        private string _message { get; set; }

        public int MessageRows { get; set; }

        private void ResizeMessageRows(string value)
        {
            MessageRows = value.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Length;
        }

        public string RemoteIPAddress { get; set; }
    }
}

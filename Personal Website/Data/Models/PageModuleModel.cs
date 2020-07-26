using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Personal_Website.Data.Models {
    public class PageModuleModel {

        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

    }
}

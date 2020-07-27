using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Personal_Website.Data.Models {
    public class PageModuleModel {

        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string Summary
        {
            get => _summary;

            set
            {
                _summary = value;
                ResizeSummaryRows(value);
            }
        }

        [NotMapped]
        private string _summary { get; set; }

        [NotMapped]
        public int SummaryRows { get; set; }

        private void ResizeSummaryRows(string value)
        {
            SummaryRows = value.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Length;
        }
    }
}

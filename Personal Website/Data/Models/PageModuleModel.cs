using System.ComponentModel.DataAnnotations;

namespace Personal_Website.Data.Models {
    public class PageModuleModel {

        [Key]
        public int Id { get; set; }
        public int SortId { get; set; }
        public int Type { get; set; }

        public string LinkId { get; set; }
        public string LinkText { get; set; }
        public string LinkGlyph { get; set; }

        public string Title { get; set; }
        public string Badges { get; set; }

        public bool CenterSummary { get; set; }
        public string Summary { get; set; }
        public string MoreSummary { get; set; }
        public string MoreSummaryId { get; set; }

        public int ImageCount { get; set; }
        public int ImageType { get; set; }
        public string ImageName { get; set; }
        public string ImageCSS { get; set; }

        public string VideoSrc { get; set; }

        public bool Active { get; set; }

    }
}

using Personal_Website.Classes.Helpers;
using Personal_Website.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Website.Classes.Extensions {
    public static class PageModuleModelExtensions {

        public static bool HasContent(this PageModuleModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Title) == false) return true;
            if (string.IsNullOrWhiteSpace(model.Summary) == false) return true;
            if (model.ImageCount > 0) return true;

            return false;
        }

        public static bool HasCardContent(this PageModuleModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Title) == false) return true;
            if (string.IsNullOrWhiteSpace(model.Summary) == false) return true;
            if (model.ImageCount > 0 && model.ImageType != (int)Enums.ImageTypes.Outside) return true;

            return false;
        }

    }
}

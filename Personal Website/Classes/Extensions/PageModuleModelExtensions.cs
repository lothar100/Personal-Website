using Personal_Website.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Website.Classes.Extensions {
    public static class PageModuleModelExtensions {

        public static bool IsEmpty(this PageModuleModel model)
        {
            bool isEmpty = true;

            if (string.IsNullOrWhiteSpace(model.Title) == false) isEmpty = false; 
            if (string.IsNullOrWhiteSpace(model.Summary) == false) isEmpty = false; 

            return isEmpty;
        }

    }
}

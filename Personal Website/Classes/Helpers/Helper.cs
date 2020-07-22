using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Personal_Website.Classes.Helpers {
    public static class Helper {

        public static string DisplayNameFor(Type modelType, string propertyName)
        {
            var attribute = modelType.GetProperty(propertyName).GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

            if (attribute == null) return string.Empty;

            return attribute.Name;
        }

    }
}

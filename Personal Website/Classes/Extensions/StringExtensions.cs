using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace Personal_Website.Classes.Extensions {
    public static class StringExtensions {

        public static string UrlEncode(this string param)
        {
            return HttpUtility.UrlEncode(param);
        }

    }
}

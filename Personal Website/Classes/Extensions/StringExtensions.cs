using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace Personal_Website.Classes.Extensions {
    public static class StringExtensions {

        public static string UrlEncode(this string value)
        {
            return HttpUtility.UrlEncode(value);
        }

        public static int RowCount(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 1;
            return value.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Length;
        }

    }
}

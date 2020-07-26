using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_Website.Classes.Extensions {
    public static class EnumerableExtensions {

        public static (bool Success, IEnumerable<T> Results) GetAny<T>(this IEnumerable<T> source, Func<T,bool> predicate)
        {
            return (source.Any(predicate), source.Where(predicate));
        }

        public static (bool Success, T Result) GetFirstAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return (source.Any(predicate), source.First(predicate));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace OptionType.Extensions
{
    public static class EnumerableExtensions
    {
        public static Option<T> FirstOrNone<T>(this IEnumerable<T> sequence) =>
            sequence.Select(Option<T>.For)
                .DefaultIfEmpty(Option<T>.None())
                .First();

        public static Option<T> FirstOrNone<T>(
            this IEnumerable<T> sequence, Func<T, bool> predicate) =>
            sequence.Where(predicate).FirstOrNone();
    }
}

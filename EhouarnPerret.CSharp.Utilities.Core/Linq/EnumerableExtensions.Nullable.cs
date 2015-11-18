using System;
using System.Collections.Generic;
using System.Linq;


namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TSource> AllValues<TSource> (this IEnumerable<TSource?> source)
            where TSource : struct
        {
            return source
                .Where(item => item.HasValue)
                .Select(item => item.Value);
        }

        public static TSource? ApplyIfAnyValuesTo<TSource> (this IEnumerable<TSource?> source, Func<IEnumerable<TSource>, TSource> func)
            where TSource : struct
        {
            var values = source.AllValues();

            return values.Any() ? func(values) : new TSource?(); 
        }
    }
}


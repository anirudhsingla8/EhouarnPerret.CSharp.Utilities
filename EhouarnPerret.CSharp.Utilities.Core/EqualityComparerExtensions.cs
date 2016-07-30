using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class EqualityComparerExtensions
    {
        public static IEqualityComparer<T> DefaultIfNull<T>(this IEqualityComparer<T> equalityComparer)
        {
            return equalityComparer ?? EqualityComparer<T>.Default;
        }
    }
}
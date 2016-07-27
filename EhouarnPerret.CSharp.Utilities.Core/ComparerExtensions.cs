using System;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class ComparerExtensions
    {
        public static Boolean AreEqual<T>(this IComparer<T> comparer, T valueLeft, T valueRight)
        {
            return comparer.Compare(valueLeft, valueRight) == 0;
        }

        public static Boolean AreNotEqual<T>(this IComparer<T> comparer, T valueLeft, T valueRight)
        {
            return comparer.Compare(valueLeft, valueRight) != 0;
        }

        public static Boolean LeftGreaterThanRight<T>(this IComparer<T> comparer, T valueLeft, T valueRight)
        {
            return comparer.Compare(valueLeft, valueRight) >= 0;
        }


        public static Boolean LeftStrictlyGreaterThanRight<T>(this IComparer<T> comparer, T valueLeft, T valueRight)
        {
            return comparer.Compare(valueLeft, valueRight) > 0;
        }

        public static Boolean RightGreaterThanLeft<T>(this IComparer<T> comparer, T valueLeft, T valueRight)
        {
            return comparer.Compare(valueLeft, valueRight) <= 0;
        }

        public static Boolean RightStrictlyGreaterThanLeft<T>(this IComparer<T> comparer, T valueLeft, T valueRight)
        {
            return comparer.Compare(valueLeft, valueRight) < 0;
        }
    }
}
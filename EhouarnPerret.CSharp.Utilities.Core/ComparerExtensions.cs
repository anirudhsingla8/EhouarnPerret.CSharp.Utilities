using System;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class ComparerExtensions
    {
        public static Boolean UncheckedIsBetween<T>(this T source, T lowerBound, T upperBound, IComparer<T> comparer = null)
        {
        }
        public static Boolean UncheckedIsStrictlyBetween<T>(this T source, T lowerBound, T upperBound, IComparer<T> comparer = null)
        {
        }
        public static Boolean UncheckedIsNotBetween<T>(this T source, T lowerBound, T upperBound, IComparer<T> comparer = null)
        {
        }
        public static Boolean UncheckedIsNotStrictlyBetween(this T source, T lowerBound, T upperBound, IComparer<T> comparer = null)
        {
        }

        public static Boolean IsBetween<T>(this T source, T lowerBound, T upperBound, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            return (comparer.Compare(lowerBound, source) <= 0) && (comparer.Compare(source, upperBound) >= 0);
        }
        public static Boolean IsStrictlyBetween<T>(this T source, T lowerBound, T upperBound, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            return (comparer.Compare(lowerBound, source) < 0) && (comparer.Compare(source, upperBound) > 0);
        }
        public static Boolean IsNotBetween<T>(this T source, T lowerBound, T upperBound, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            return (comparer.Compare(lowerBound, source) > 0) && (comparer.Compare(source, upperBound) < 0);
        }
        public static Boolean IsStrictlyNotBetween<T>(this T source, T lowerBound, T upperBound, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;

        }

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
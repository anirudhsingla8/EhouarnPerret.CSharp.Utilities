using System;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class ComparerExtensions
    {
        public static IComparer<T> DefaultIfNull<T>(this IComparer<T> comparer)
        {
            return comparer ?? Comparer<T>.Default;
        } 

        public static bool AreEqual<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) == 0;
        }
        public static bool AreNotEqual<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) != 0;
        }

        public static bool IsLeftGreaterThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) >= 0;
        }
        public static bool IsLeftStrictlyGreaterThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) > 0;
        }

        public static bool IsLeftLesserThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) <= 0;
        }
        public static bool IsLeftStrictlyLesserThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) < 0;
        }
        
        // TODO: refactoring
        public static bool IsLeftNotGreaterThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsLeftGreaterThanRight(left, right);
        }
        // TODO: refactoring
        public static bool IsLeftStrictlyNotGreaterThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsLeftStrictlyGreaterThanRight(left, right);
        }

        // TODO: refactoring
        public static bool IsLeftNotLesserThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsLeftLesserThanRight(left, right);
        }
        // TODO: refactoring
        public static bool IsLeftStrictlyNotLesserThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsLeftStrictlyLesserThanRight(left, right);
        }

        public static bool IsRightGreaterThanLeft<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) <= 0;
        }
        public static bool IsRightStrictlyGreaterThanLeft<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) < 0;
        }

        // TODO: refactoring
        public static bool IsRightNotGreaterThanLeft<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsRightGreaterThanLeft(left, right);
        }
        // TODO: refactoring
        public static bool IsRightNotStrictlyGreaterThanLeft<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsRightStrictlyGreaterThanLeft(left, right);
        }

        // TODO: refactoring
        public static bool IsValueBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            if (comparer.IsLeftStrictlyGreaterThanRight(lowerBound, upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            return comparer.UncheckedIsValueBetweenBounds(value, lowerBound, upperBound);
        }

        // TODO: refactoring
        public static bool IsValueStrictlyBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            if (comparer.IsLeftGreaterThanRight(lowerBound, upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            return comparer.UncheckedIsValueStrictlyBetweenBounds(value, lowerBound, upperBound);
        }
        
        // TODO: refactoring
        public static bool IsValueNotBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            return !comparer.IsValueBetweenBounds(value, lowerBound, upperBound);
        }
        
        // TODO: refactoring
        public static bool IsValueStrictlyNotBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            return !comparer.IsValueStrictlyBetweenBounds(value, lowerBound, upperBound);
        }



        // TODO: refactoring
        internal static bool UncheckedIsValueBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            return comparer.IsLeftLesserThanRight(lowerBound, value) && comparer.IsLeftLesserThanRight(value, upperBound);
        }

        // TODO: refactoring
        internal static bool UncheckedIsValueStrictlyBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            return comparer.IsLeftStrictlyLesserThanRight(lowerBound, value) && comparer.IsLeftStrictlyLesserThanRight(value, upperBound);
        }

        // TODO: refactoring
        internal static bool UncheckedIsValueNotBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            return !comparer.UncheckedIsValueBetweenBounds(value, lowerBound, upperBound);
        }

        // TODO: refactoring
        internal static bool UncheckedIsValueStrictlyNotBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            return !comparer.UncheckedIsValueStrictlyBetweenBounds(value, lowerBound, upperBound);
        }
    }
}
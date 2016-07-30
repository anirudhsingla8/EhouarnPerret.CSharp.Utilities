using System;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class ComparerExtensions
    {
        public static Boolean AreEqual<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) == 0;
        }
        public static Boolean AreNotEqual<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) != 0;
        }

        public static Boolean IsLeftGreaterThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) >= 0;
        }
        public static Boolean IsLeftStrictlyGreaterThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) > 0;
        }

        public static Boolean IsLeftLesserThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) <= 0;
        }
        public static Boolean IsLeftStrictlyLesserThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) < 0;
        }
        
        // TODO: refactoring
        public static Boolean IsLeftNotGreaterThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsLeftGreaterThanRight(left, right);
        }
        // TODO: refactoring
        public static Boolean IsLeftNotStrictlyGreaterThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsLeftStrictlyGreaterThanRight(left, right);
        }

        // TODO: refactoring
        public static Boolean IsLeftNotLesserThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsLeftLesserThanRight(left, right);
        }
        // TODO: refactoring
        public static Boolean IsLeftNotStrictlyLesserThanRight<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsLeftStrictlyLesserThanRight(left, right);
        }

        public static Boolean IsRightGreaterThanLeft<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) <= 0;
        }
        public static Boolean IsRightStrictlyGreaterThanLeft<T>(this IComparer<T> comparer, T left, T right)
        {
            return comparer.Compare(left, right) < 0;
        }

        // TODO: refactoring
        public static Boolean IsRightNotGreaterThanLeft<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsRightGreaterThanLeft(left, right);
        }
        // TODO: refactoring
        public static Boolean IsRightNotStrictlyGreaterThanLeft<T>(this IComparer<T> comparer, T left, T right)
        {
            return !comparer.IsRightStrictlyGreaterThanLeft(left, right);
        }

        // TODO: refactoring
        public static Boolean IsValueBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            if (comparer.IsLeftStrictlyGreaterThanRight(lowerBound, upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            else
            {
                return comparer.IsLeftLesserThanRight(lowerBound, value) &&
                       comparer.IsLeftLesserThanRight(value, upperBound);
            }
        }

        // TODO: refactoring
        public static Boolean IsValueStrictlyBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            if (comparer.IsLeftGreaterThanRight(lowerBound, upperBound))
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            else
            {
                return comparer.IsLeftStrictlyLesserThanRight(lowerBound, value) &&
                       comparer.IsLeftStrictlyLesserThanRight(value, upperBound);
            }
        }
        
        // TODO: refactoring
        public static Boolean IsValueNotBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            return !comparer.IsValueBetweenBounds(value, lowerBound, upperBound);
        }
        // TODO: refactoring
        public static Boolean IsValueNotStrictlyBetweenBounds<T>(this IComparer<T> comparer, T value, T lowerBound, T upperBound)
        {
            return !comparer.IsValueStrictlyBetweenBounds(value, lowerBound, upperBound);
        }
    }
}
//
// MathHelpers.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) Ehouarn Perret
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Numerics;
using System.Drawing;

namespace EhouarnPerret.CSharp.Utilities.Core.Numeric
{
    public static class MathHelpers
    {
        //        public static BigInteger FactorialApproximate(FactorialApproximationScheme scheme)
        //        {
        //            
        //        }
        //        public IEnumerable<BigInteger> PrimeFactorizationDirectSearch(BigInteger n)
        //        {
        //            HashSet<Int32> d;
        //        }
        //
        //        public IEnumerable<BigInteger> EratosthenesSieve(BigInteger n)
        //        {
        //            
        //        }
        //        public static BigIntegerFraction SquareRootBabylonianScheme(BigInteger value)
        //        {
        //
        //        }
        //        public static BigIntegerFraction SquareRootBakhshaliScheme(BigInteger value)
        //        {
        //
        //        }
        //        public static BigIntegerFraction SquareRootNewtonScheme(BigInteger value)
        //        {
        //        }
        //        public static BigIntegerFraction SquareRootExponentialIdentityScheme(BigInteger value)
        //        {
        //        }

        public static T Min<T>(T val1, T val2)
            where T : IComparable<T>
        {
            return val1.CompareTo(val2) <= 0 ? val1 : val2;
        }

        public static T Max<T>(T val1, T val2)
            where T : IComparable<T>
        {
            return val1.CompareTo(val2) >= 0 ? val1 : val2;
        }

        private static BigInteger FactorialNaiveIterative(ushort n)
        {
            var product = BigInteger.One;

            for (var i = 1; i <= n; i++)
            {
                product *= i;
            }

            return product;
        }
        private static BigInteger FactorialNaiveRecursive(ushort n)
        {
            if (n == 0)
            {
                return BigInteger.One;
            }
            return n * FactorialNaiveRecursive((ushort)(n - 1));
        }
    
        public static double EuclidianDistance(PointF pointA, PointF pointB)
        {
            return Math.Sqrt(Math.Pow(pointB.Y - pointA.Y, 2) + Math.Pow(pointB.X - pointA.X, 2));
        }
        public static double EuclidianDistance(Point pointA, Point pointB)
        {
            return Math.Sqrt(Math.Pow(pointB.Y - pointA.Y, 2) + Math.Pow(pointB.X - pointA.X, 2));
        }

        public static uint GCDBinary(uint a, uint b, GCDBinaryScheme scheme = GCDBinaryScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDBinaryScheme.Iterative: return GCDBinaryIterative(a, b);
                case GCDBinaryScheme.Recursive: return GCDBinaryRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }
        public static ulong GCDBinary(ulong a, ulong b, GCDBinaryScheme scheme = GCDBinaryScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDBinaryScheme.Iterative: return GCDBinaryIterative(a, b);
                case GCDBinaryScheme.Recursive: return GCDBinaryRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }

        // Add new methods to handle more than two numbers...

        public static uint GCDBinaryRecursive(uint a, uint b)
        {
            // Simple cases (termination)
            if (a == b)
            {
                return a;
            }
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }
            // Look for factors of 2
            // a is even
            if ((~a & 1) > 0)
            {
                // b is odd
                if ((b & 1) > 0) 
                {
                    return GCDBinaryRecursive(a >> 1, b);
                }
                return GCDBinaryRecursive(a >> 1, b >> 1) << 1;
            }

            // a is odd and b is eben
            if ((~b & 1) > 0)
            {
                return GCDBinaryRecursive(a, b >> 1);
            }
            // Reduce larger argument
            if (a > b)
            {
                return GCDBinaryRecursive((a - b) >> 1, b);
            }
            return GCDBinaryRecursive((b - a) >> 1, a);
        }
        public static uint GCDBinaryIterative(uint a, uint b)
        {
            int shift;

            // GCD(0,v) == v; GCD(u,0) == u, GCD(0,0) == 0
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }
            // Let shift := lg K, where K is the greatest power of 2 dividing both a and v.
            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            // From here on, a is always odd.
            do
            {
                // Remove all factors of 2 in b -- they are not common
                // Note: b is not zero, so while will terminate
                // Loop X
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                // Now a and b are both odd. Swap if necessary so a <= v,
                // then set b = b - a (which is even). 

                // For bignums, the swapping is just pointer movement, 
                // and the subtraction can be done in-place.

                if (a > b)
                {
                    var temp = b; 
                    b = a; 
                    a = temp;
                }  

                // Swap a and v.
                // Here b >= u.
                b = b - a;                       
            }
            while (b != 0);

            // Restore common factors of
            return a << shift;
        }
        public static ulong GCDBinaryRecursive(ulong a, ulong b)
        {
            // Simple cases (termination)
            if (a == b)
            {
                return a;
            }
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }
            // Look for factors of 2
            // a is even
            if ((~a & 1) > 0)
            {
                // b is odd
                if ((b & 1) > 0) 
                {
                    return GCDBinaryRecursive(a >> 1, b);
                }
                return GCDBinaryRecursive(a >> 1, b >> 1) << 1;
            }

            // a is odd and b is eben
            if ((~b & 1) > 0)
            {
                return GCDBinaryRecursive(a, b >> 1);
            }
            // Reduce larger argument
            if (a > b)
            {
                return GCDBinaryRecursive((a - b) >> 1, b);
            }
            return GCDBinaryRecursive((b - a) >> 1, a);
        }
        public static ulong GCDBinaryIterative(ulong a, ulong b)
        {
            int shift;

            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }
            // Let shift := lg K, where K is the greatest power of 2 dividing both a and v.
            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            // From here on, a is always odd.
            do
            {
                // Remove all factors of 2 in b -- they are not common
                // Note: b is not zero, so while will terminate
                // Loop X
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                // Now a and b are both odd. Swap if necessary so a <= v,
                // then set b = b - a (which is even). 

                // For big numbers, the swapping is just pointer movement, 
                // and the subtraction can be done in-place.

                if (a > b)
                {
                    var temp = b; 
                    b = a; 
                    a = temp;
                }  

                // Swap a and b.
                // Here b >= a.
                b = b - a;                       
            }
            while (b != 0);

            // Restore common factors of
            return a << shift;
        }

        public static sbyte GCDEuclideIterative(sbyte a, sbyte b)
        {
            while (b != 0)
            {
                var temp = b;

                b = (sbyte)(a % b);

                a = temp;
            }

            return a;
        }
        public static short GCDEuclideIterative(short a, short b)
        {
            while (b != 0)
            {
                var temp = b;

                b = (short)(a % b);

                a = temp;
            }

            return a;
        }
        public static int GCDEuclideIterative(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;

                b = a % b;

                a = temp;
            }

            return a;
        }
        public static long GCDEuclideIterative(long a, long b)
        {
            while (b != 0)
            {
                var temp = b;

                b = a % b;

                a = temp;
            }

            return a;
        }

        public static byte GCDEuclideIterative(byte a, byte b)
        {
            while (b != 0)
            {
                var temp = b;

                b = (byte)(a % b);

                a = temp;
            }

            return a;
        }
        public static ushort GCDEuclideIterative(ushort a, ushort b)
        {
            while (b != 0)
            {
                var temp = b;

                b = (ushort)(a % b);

                a = temp;
            }

            return a;
        }
        public static uint GCDEuclideIterative(uint a, uint b)
        {
            while (b != 0)
            {
                var temp = b;

                b = (uint)a % b;

                a = temp;
            }

            return a;
        }
        public static ulong GCDEuclideIterative(ulong a, ulong b)
        {
            while (b != 0)
            {
                var temp = b;

                b = a % b;

                a = temp;
            }

            return a;
        }

        public static sbyte GCDEuclideRecursive(sbyte a, sbyte b)
        {
            return b == 0 ? a : GCDEuclideRecursive(b, (sbyte)(a % b));
        }
        public static short GCDEuclideRecursive(short a, short b)
        {
            return b == 0 ? a : GCDEuclideRecursive(b, (short)(a % b));
        }
        public static int GCDEuclideRecursive(int a, int b)
        {
            return b == 0 ? a : GCDEuclideRecursive(b, a % b);
        }
        public static long GCDEuclideRecursive(long a, long b)
        {
            return b == 0 ? a : GCDEuclideRecursive(b, a % b);
        }

        public static byte GCDEuclideRecursive(byte a, byte b)
        {
            return b == 0 ? a : GCDEuclideRecursive(b, (byte)(a % b));
        }
        public static ushort GCDEuclideRecursive(ushort a, ushort b)
        {
            return b == 0 ? a : GCDEuclideRecursive(b, (ushort)(a % b));
        }
        public static uint GCDEuclideRecursive(uint a, uint b)
        {
            return b == 0 ? a : GCDEuclideRecursive(b, a % b);
        }
        public static ulong GCDEuclideRecursive(ulong a, ulong b)
        {
            return b == 0 ? a : GCDEuclideRecursive(b, a % b);
        }

        public static sbyte GCDEuclide(sbyte a, sbyte b, GCDEuclideScheme scheme = GCDEuclideScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDEuclideScheme.Iterative: return GCDEuclideIterative(a, b);
                case GCDEuclideScheme.Recursive: return GCDEuclideRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }
        public static short GCDEuclide(short a, short b, GCDEuclideScheme scheme = GCDEuclideScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDEuclideScheme.Iterative: return GCDEuclideIterative(a, b);
                case GCDEuclideScheme.Recursive: return GCDEuclideRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }
        public static int GCDEuclide(int a, int b, GCDEuclideScheme scheme = GCDEuclideScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDEuclideScheme.Iterative: return GCDEuclideIterative(a, b);
                case GCDEuclideScheme.Recursive: return GCDEuclideRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }
        public static long GCDEuclide(long a, long b, GCDEuclideScheme scheme = GCDEuclideScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDEuclideScheme.Iterative: return GCDEuclideIterative(a, b);
                case GCDEuclideScheme.Recursive: return GCDEuclideRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }

        public static byte GCDEuclide(byte a, byte b, GCDEuclideScheme scheme = GCDEuclideScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDEuclideScheme.Iterative: return GCDEuclideIterative(a, b);
                case GCDEuclideScheme.Recursive: return GCDEuclideRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }
        public static ushort GCDEuclide(ushort a, ushort b, GCDEuclideScheme scheme = GCDEuclideScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDEuclideScheme.Iterative: return GCDEuclideIterative(a, b);
                case GCDEuclideScheme.Recursive: return GCDEuclideRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }
        public static uint GCDEuclide(uint a, uint b, GCDEuclideScheme scheme = GCDEuclideScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDEuclideScheme.Iterative: return GCDEuclideIterative(a, b);
                case GCDEuclideScheme.Recursive: return GCDEuclideRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }
        public static ulong GCDEuclide(ulong a, ulong b, GCDEuclideScheme scheme = GCDEuclideScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDEuclideScheme.Iterative: return GCDEuclideIterative(a, b);
                case GCDEuclideScheme.Recursive: return GCDEuclideRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }
    }
}


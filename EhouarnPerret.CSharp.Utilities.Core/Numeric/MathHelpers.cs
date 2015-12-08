//
// MathHelpers.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) 2015 Ehouarn Perret
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
using System.Collections.Generic;
using System.Drawing;

namespace EhouarnPerret.CSharp.Utilities.Core
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

        private static BigInteger FactorialNaiveIterative(UInt16 n)
        {
            var product = BigInteger.One;

            for (var i = 1; i <= n; i++)
            {
                product *= i;
            }

            return product;
        }
        private static BigInteger FactorialNaiveRecursive(UInt16 n)
        {
            if (n == 0)
            {
                return BigInteger.One;
            }
            else
            {
                return n * MathHelpers.FactorialNaiveRecursive((UInt16)(n - 1));
            }
        }
    
        public static Double EuclidianDistance(PointF pointA, PointF pointB)
        {
            return Math.Sqrt(Math.Pow(pointB.Y - pointA.Y, 2) + Math.Pow(pointB.X - pointA.X, 2));
        }
        public static Double EuclidianDistance(Point pointA, Point pointB)
        {
            return Math.Sqrt(Math.Pow(pointB.Y - pointA.Y, 2) + Math.Pow(pointB.X - pointA.X, 2));
        }

        public static UInt32 GCDBinaryRecursive(UInt32 a, UInt32 b, GCDBinaryScheme scheme = GCDBinaryScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDBinaryScheme.Iterative: return MathHelpers.GCDBinaryIterative(a, b);
                case GCDBinaryScheme.Recursive: return MathHelpers.GCDBinaryRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }
        public static UInt64 GCDBinaryRecursive(UInt64 a, UInt64 b, GCDBinaryScheme scheme = GCDBinaryScheme.Iterative)
        {
            switch (scheme)
            {
                case GCDBinaryScheme.Iterative: return MathHelpers.GCDBinaryIterative(a, b);
                case GCDBinaryScheme.Recursive: return MathHelpers.GCDBinaryRecursive(a, b);
                default: throw new NotImplementedException(nameof(scheme));
            }
        }

        public static UInt32 GCDBinaryRecursive(UInt32 a, UInt32 b)
        {
            // Simple cases (termination)
            if (a == b)
            {
                return a;
            }
            else if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }
            // Look for factors of 2
            // a is even
            else if ((~a & 1) > 0) 
            {
                // b is odd
                if ((b & 1) > 0) 
                {
                    return MathHelpers.GCDBinaryRecursive(a >> 1, b);
                }
                else // both a and b are eben
                {
                    return MathHelpers.GCDBinaryRecursive(a >> 1, b >> 1) << 1;
                }
            }

            // a is odd and b is eben
            if ((~b & 1) > 0)
            {
                return MathHelpers.GCDBinaryRecursive(a, b >> 1);
            }
            // Reduce larger argument
            else if (a > b)
            {
                return MathHelpers.GCDBinaryRecursive((a - b) >> 1, b);
            }
            else
            {
                return MathHelpers.GCDBinaryRecursive((b - a) >> 1, a);
            }
        }
        public static UInt32 GCDBinaryIterative(UInt32 a, UInt32 b)
        {
            Int32 shift;

            // GCD(0,v) == v; GCD(u,0) == u, GCD(0,0) == 0
            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }
            else
            {
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
        }
        public static UInt64 GCDBinaryRecursive(UInt64 a, UInt64 b)
        {
            // Simple cases (termination)
            if (a == b)
            {
                return a;
            }
            else if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }
            // Look for factors of 2
            // a is even
            else if ((~a & 1) > 0) 
            {
                // b is odd
                if ((b & 1) > 0) 
                {
                    return MathHelpers.GCDBinaryRecursive(a >> 1, b);
                }
                else // both a and b are eben
                {
                    return MathHelpers.GCDBinaryRecursive(a >> 1, b >> 1) << 1;
                }
            }

            // a is odd and b is eben
            if ((~b & 1) > 0)
            {
                return MathHelpers.GCDBinaryRecursive(a, b >> 1);
            }
            // Reduce larger argument
            else if (a > b)
            {
                return MathHelpers.GCDBinaryRecursive((a - b) >> 1, b);
            }
            else
            {
                return MathHelpers.GCDBinaryRecursive((b - a) >> 1, a);
            }
        }
        public static UInt64 GCDBinaryIterative(UInt64 a, UInt64 b)
        {
            Int32 shift;

            // GCD(0,v) == v; GCD(u,0) == u, GCD(0,0) == 0
            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }
            else
            {
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
        }

//        public static Int32 GCDBinaryEuclide(Int32 a, Int32 b)
//        {
//        }
    }

    public enum GCDBinaryScheme : byte
    {
        Iterative = 0x00,
        Recursive = 0x01,
    }
}


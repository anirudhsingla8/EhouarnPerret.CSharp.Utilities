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
    }
}


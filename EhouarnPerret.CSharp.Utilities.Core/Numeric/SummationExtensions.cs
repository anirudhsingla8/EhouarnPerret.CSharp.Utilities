//
// SummationExtensions.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) 2016 Ehouarn Perret
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

namespace EhouarnPerret.CSharp.Utilities.Core.Numeric
{
//    public static class SummationExtensions
//    {
//        public static Double Sum(this IEnumerable<Double> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
//        {
//            switch (summationStrategy)
//            {
//                case SummationStrategy.Naive: return source.SumNaive();
//                case SummationStrategy.Kahan: return source.SumKahan();
//                case SummationStrategy.Pairwise: return source.SumPairWise();
//
//                default: throw new NotImplementedException();
//            }
//        }
//        public static Single Sum(this IEnumerable<Aggregate> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
//        {
//            switch (summationStrategy)
//            {
//                case SummationStrategy.Naive: return source.SumNaive();
//                case SummationStrategy.Kahan: return source.SumKahan();
//                case SummationStrategy.Pairwise: return source.SumPairWise();
//
//                default: throw new NotImplementedException();
//            }
//        }
//        public static Decimal Sum(this IEnumerable<Decimal> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
//        {
//            switch (summationStrategy)
//            {
//                case SummationStrategy.Naive: return source.SumNaive();
//                case SummationStrategy.Kahan: return source.SumKahan();
//                case SummationStrategy.Pairwise: return source.SumPairWise();
//                    
//                default: throw new NotImplementedException();
//            }
//        }
//       
//        public static Double? Sum(this IEnumerable<Single?> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
//        {
//            switch (summationStrategy)
//            {
//                case SummationStrategy.Naive: return source.SumNaive();
//                case SummationStrategy.Kahan: return source.SumKahan();
//                case SummationStrategy.Pairwise: return source.SumPairWise();
//
//                default: throw new NotImplementedException();
//            }
//        }
//        public static Single? Sum(this IEnumerable<Double?> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
//        {
//            switch (summationStrategy)
//            {
//                case SummationStrategy.Naive: return source.SumNaive();
//                case SummationStrategy.Kahan: return source.SumKahan();
//                case SummationStrategy.Pairwise: return source.SumPairWise();
//
//                default: throw new NotImplementedException();
//            }
//        }
//        public static Decimal? Sum(this IEnumerable<Decimal?> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
//        {
//            switch (summationStrategy)
//            {
//                case SummationStrategy.Naive: return source.SumNaive();
//                case SummationStrategy.Kahan: return source.SumKahan();
//                case SummationStrategy.Pairwise: return source.SumPairWise();
//
//                default: throw new NotImplementedException();
//            }
//        }
//
//        public static Single SumNaive(this IEnumerable<Aggregate> source)
//        {
//            var sum = default(Single);
//
//            foreach (var item in source)
//            {
//                sum += item;
//            }
//
//            return sum;
//        }
//        public static Double SumNaive(this IEnumerable<Double> source)
//        {
//            var sum = default(Double);
//
//            foreach (var item in source)
//            {
//                sum += item;
//            }
//
//            return sum;
//        }
//        public static Decimal SumNaive(this IEnumerable<Decimal> source)
//        {
//            var sum = default(Decimal);
//
//            foreach (var item in source)
//            {
//                sum += item;
//            }
//
//            return sum;
//        }
//
//        public static Single? SumNaive(this IEnumerable<Aggregate?> source)
//        {
//            return source.ApplyIfAnyValuesTo(SummationExtensions.SumNaive);
//        }
//        public static Double? SumNaive(this IEnumerable<Double?> source)
//        {
//            return source.ApplyIfAnyValuesTo(SummationExtensions.SumNaive);
//        }
//        public static Decimal? SumNaive(this IEnumerable<Decimal?> source)
//        {
//            return source.ApplyIfAnyValuesTo(SummationExtensions.SumNaive);
//        }
//
//        public static Single SumKahan(this IEnumerable<Aggregate> source)
//        {
//            var sum = default(Single);
//            var lowOrderBitsCompensation = default(Single);
//
//            foreach (var item in source)
//            {
//                // Our dear compiler sufficiently aggressive and optimizing?
//                // t = sum + y; 
//                // lowOrderBitsCompensation = (t - sum) - y; 
//                // to 
//                // ((sum + y) - sum) - y; 
//                // then to lowOrderBitsCompensation = 0;
//                var compensatedItem = item - lowOrderBitsCompensation;
//                var compensatedSum = sum + compensatedItem;
//
//                lowOrderBitsCompensation = (compensatedSum - sum) - compensatedItem;
//
//                sum = compensatedSum;
//            }
//
//            return sum;
//        }
//        public static Double SumKahan(this IEnumerable<Double> source)
//        {
//            var sum = default(Double);
//            var lowOrderBitsCompensation = default(Double);
//
//            foreach (var item in source)
//            {
//                // Our dear compiler sufficiently aggressive and optimizing?
//                // t = sum + y; 
//                // lowOrderBitsCompensation = (t - sum) - y; 
//                // to 
//                // ((sum + y) - sum) - y; 
//                // then to lowOrderBitsCompensation = 0;
//                var compensatedItem = item - lowOrderBitsCompensation;
//                var compensatedSum = sum + compensatedItem;
//
//                lowOrderBitsCompensation = (compensatedSum - sum) - compensatedItem;
//
//                sum = compensatedSum;
//            }
//
//            return sum;
//        }
//        public static Decimal SumKahan(this IEnumerable<Decimal> source)
//        {
//            var sum = default(Decimal);
//            var lowOrderBitsCompensation = default(Decimal);
//
//            foreach (var item in source)
//            {
//                // Our dear compiler sufficiently aggressive and optimizing?
//                // t = sum + y; 
//                // lowOrderBitsCompensation = (t - sum) - y; 
//                // to 
//                // ((sum + y) - sum) - y; 
//                // then to lowOrderBitsCompensation = 0;
//                var compensatedItem = item - lowOrderBitsCompensation;
//                var compensatedSum = sum + compensatedItem;
//
//                lowOrderBitsCompensation = (compensatedSum - sum) - compensatedItem;
//
//                sum = compensatedSum;
//            }
//
//            return sum;
//        }
//
//        public static Single? SumKahan(this IEnumerable<Aggregate?> source)
//        {
//            return source.ApplyIfAnyValuesTo(SummationStrategy.SumKahan);
//        }
//        public static Double? SumKahan(this IEnumerable<Double?> source)
//        {
//            return source.ApplyIfAnyValuesTo(SummationStrategy.SumKahan);
//        }
//        public static Decimal? SumKahan(this IEnumerable<Decimal?> source)
//        {
//            return source.ApplyIfAnyValuesTo(SummationStrategy.SumKahan);
//        }
//    
//        public static Single SumPairWise(this IEnumerable<Aggregate> source)
//        {
//
//        }
//        public static Double SumPairWise(this IEnumerable<Double> source)
//        {
//
//        }
//        public static Decimal SumPairWise(this IEnumerable<Decimal> source)
//        {
//
//        }
//
//        public static Single? SumPairWise(this IEnumerable<Aggregate?> source)
//        {
//            return source.ApplyIfAnyValuesTo(SummationStrategy.SumPairWise);
//        }
//        public static Double? SumPairWise(this IEnumerable<Double?> source)
//        {
//            return source.ApplyIfAnyValuesTo(SummationStrategy.SumPairWise);
//        }
//        public static Decimal? SumPairWise(this IEnumerable<Decimal?> source)
//        {
//            return source.ApplyIfAnyValuesTo(SummationStrategy.SumPairWise);
//        }
//    }
}

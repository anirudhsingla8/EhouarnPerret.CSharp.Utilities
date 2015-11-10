//
//  Copyright 2015  Ehouarn Perret
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
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
//        public static Single Sum(this IEnumerable<Single> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
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
//        public static Single SumNaive(this IEnumerable<Single> source)
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
//        public static Single? SumNaive(this IEnumerable<Single?> source)
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
//        public static Single SumKahan(this IEnumerable<Single> source)
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
//        public static Single? SumKahan(this IEnumerable<Single?> source)
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
//        public static Single SumPairWise(this IEnumerable<Single> source)
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
//        public static Single? SumPairWise(this IEnumerable<Single?> source)
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

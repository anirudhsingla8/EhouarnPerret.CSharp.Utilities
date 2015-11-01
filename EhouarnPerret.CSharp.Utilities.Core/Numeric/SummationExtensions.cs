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
    public static class SummationExtensions
    {
        public static Decimal Sum(this IEnumerable<Decimal> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
        {
            switch (summationStrategy)
            {
                case SummationStrategy.Naive:
                    break;

                case SummationStrategy.Kahan:
                    break;

                case SummationStrategy.Pairwise:
                    break;

                default:
                    break;
            }
        }
        public static Double Sum(this IEnumerable<Double> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
        {
        }
        public static Single Sum(this IEnumerable<Single> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
        {
        }
        public static Decimal? Sum(this IEnumerable<Decimal?> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
        {
        }
        public static Double? Sum(this IEnumerable<Single?> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
        {
        }
        public static Single? Sum(this IEnumerable<Double?> source, SummationStrategy summationStrategy = SummationStrategy.Naive)
        {
        }

        public static Single SumNaive(this IEnumerable<Single> source)
        {
            var sum = default(Single);

            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }
        public static Double SumNaive(this IEnumerable<Double> source)
        {
            var sum = default(Double);

            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }
        public static Decimal SumNaive(this IEnumerable<Decimal> source)
        {
            var sum = default(Decimal);

            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }
        public static Single? SumNaive(this IEnumerable<Single?> source)
        {
            var sum = default(Single?);

            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }
        public static Double? SumNaive(this IEnumerable<Double?> source)
        {
            var sum = default(Double?);

            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }
        public static Decimal? SumNaive(this IEnumerable<Decimal?> source)
        {
            var sum = default(Decimal?);

            foreach (var item in source)
            {
                sum += item;
            }

            return sum;
        }

    }
}

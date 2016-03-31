//
// StatisticExtensions.cs
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

using System;
using System.Linq;
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core.Numeric
{
//    public static class StatisticExtensions
//    {
//        public static Decimal StandardDeviation(this IEnumerable<Decimal> source)
//        {
//        }
//        public static Decimal? StandardDeviation(this IEnumerable<Decimal?> source)
//        {
//            
//            var values = source.AllValues();
//
//            return values.Any() ? values.StandardDeviation() : null;
//        }
//        public static Single StandardDeviation(this IEnumerable<Single> source)
//        {
//        }
//        public static Single? StandardDeviation(this IEnumerable<Single?> source)
//        {
//            var values = source.AllValues();
//
//            return values.Any() ? values.StandardDeviation() : null;
//        }
//        public static Double StandardDeviation(this IEnumerable<Double> source)
//        {
//        }
//        public static Double? StandardDeviation(this IEnumerable<Decimal?> source)
//        {
//            var values = source.AllValues();
//
//            return values.Any() ? values.StandardDeviation() : null;
//        }
//
//        public static Decimal Variance(this IEnumerable<Decimal> source)
//        {
//            var n = default(Int32);
//            var mean = default(Decimal);
//            var M2 = default(Decimal);
//
//            foreach (var value in source)
//            {
//                n = n + 1;
//                var delta = value - mean;
//                mean = mean + delta / n;
//                M2 += delta * (value - mean);
//            }
//
//            return M2 / (n - 1);
//        }
//        public static Decimal? Variance(this IEnumerable<Decimal?> source)
//        {
//            var actualValues = values.AllValues();
//
//            return actualValues.Any() ? actualValues.StandardDeviation() : null;
//        }
//        public static Single Variance(this IEnumerable<Single> source)
//        {
//
//        }
//        public static Single? Variance(this IEnumerable<Single?> source)
//        {
//            var actualValues = values.AllValues();
//
//            return actualValues.Any() ? actualValues.StandardDeviation() : null;
//        }
//        public static Double Variance(this IEnumerable<Double> source)
//        {
//            
//        }
//        public static Double? Variance(this IEnumerable<Double?> source)
//        {
//            var actualValues = values.AllValues();
//
//            return actualValues.Any() ? actualValues.StandardDeviation() : null;
//        }
//
//        public static Single MeanCompensated(this IEnumerable<Single> source)
//        {
//            var sum = default(Single);
//            var lowOrderBitsCompensation = default(Single);
//
//            foreach (var item in source)
//            {
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
//        public static Double MeanCompensated(this IEnumerable<Double> source)
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
//        public static Decimal MeanCompensated(this IEnumerable<Decimal> source)
//        {
//        }
//        public static Single? MeanCompensated(this IEnumerable<Single> source)
//        {
//        }
//        public static Double? MeanCompensated(this IEnumerable<Double> source)
//        {
//        }
//        public static Decimal? MeanCompensated(this IEnumerable<Decimal> source)
//        {
//        }
//
//        public static Double VarianceOnePassNaive(this IEnumerable<Double> source)
//        {
//            var count = default(Double);
//            var sum = default(Double);
//            var differenceSquaresSum = default(Double);
//
//            foreach (var value in source)
//            {
//                count++;
//                sum += value;
//                differenceSquaresSum += value * value;
//            }
//
//            var variance = ((differenceSquaresSum - (sum * sum)) / count) / (count - 1);
//
//            return variance;
//        }
//        public static Double VarianceOnePassComputedShiftedData(this IEnumerable<Double> source)
//        {
//            return source.VarianceComputedShiftedData(source.First());
//        }
//        public static Double VarianceOnePassComputedShiftedData(this IEnumerable<Double> source, Double shift)
//        {
//            var count = default(Double);
//            var sum = default(Double);
//
//            var differenceSquaresSum = default(Double);
//
//            foreach (var value in source) 
//            {
//                count++;
//                var difference = (value - shift);
//                sum += difference;
//                differenceSquaresSum += difference * difference;
//            }
//
//            var variance = (differenceSquaresSum - (sum * sum) / count) / (count - 1);
//
//            return variance;
//        }
//        public static Double VarianceTwoPassNaive(this IEnumerable<Double> source)
//        {
//            var count = default(Double);
//            var sum = default(Double);
//            var differenceSquaresSum = default(Double);
//
//            // No we are not going with the line below,
//            // We want to avoid re-computing count... twice
//            // (Yup even implicitely... =])
//            // var mean = source.Mean();
//
//            foreach (var value in source)
//            {
//                count++;
//                sum += value;
//            }
//
//            var mean = sum / count;
//
//            foreach (var value in source)
//            {
//                var difference = value - mean;
//                differenceSquaresSum += difference * difference;
//            }
//
//            var variance = differenceSquaresSum / (count - 1);
//
//            return variance;
//        }
//        public static Double VarianceTwoPassCompensated(this IEnumerable<Double> source)
//        {
//            var count = default(Double);
//            var sum = default(Double);
//
//            foreach (var value in source)
//            {
//                count++;
//                sum += value;
//            }
//
//            source.Sum();
//
//            var mean = sum / count;
//
//            foreach (var value in source)
//            {
//                
//            }
//        }
//
//        public static Decimal VarianceOnePassNaive(this IEnumerable<Decimal> source)
//        {
//            var count = default(Decimal);
//            var sum = default(Decimal);
//            var differenceSquaresSum = default(Decimal);
//
//            foreach (var value in source)
//            {
//                count++;
//                sum += value;
//                differenceSquaresSum += value * value;
//            }
//
//            var variance = ((differenceSquaresSum - (sum * sum)) / count) / (count - 1);
//
//            return variance;
//        }
//        public static Decimal VarianceOnePassComputedShiftedData(this IEnumerable<Decimal> source)
//        {
//            var shift = source.First();
//            var count = default(Decimal);
//            var sum = default(Decimal);
//            var differenceSquaresSum = default(Decimal);
//
//            foreach (var value in source) 
//            {
//                count++;
//                var difference = (value - shift);
//                sum += difference;
//                differenceSquaresSum += difference * difference;
//            }
//
//            var variance = (differenceSquaresSum - (sum * sum) / count) / (count - 1);
//
//            return variance;
//        }
//
//        public static Double Mode(this IEnumerable<Double> source)
//        {
//        }
//        public static Double? Mode(this IEnumerable<Double?> source)
//        {
//
//        }
//        public static Decimal Mode(this IEnumerable<Decimal> source)
//        {
//
//        }
//        public static Decimal? Mode(this IEnumerable<Decimal?> source)
//        {
//
//        }
//
//        public static Double Median(this IEnumerable<Double> source)
//        {
//        }
//        public static Double? Median(this IEnumerable<Double?> source)
//        {
//        }
//        public static Decimal Median(this IEnumerable<Decimal> source)
//        {
//        }
//        public static Decimal? Median(this IEnumerable<Decimal> source)
//        {
//        }
//
//        public static Double Range(this IEnumerable<Double> source)
//        {
//        }
//        public static Double? Range(this IEnumerable<Double?> source)
//        {
//        }
//        public static Decimal Range(this IEnumerable<Decimal> source)
//        {
//        }
//        public static Decimal Range(this IEnumerable<Decimal?> source)
//        {
//
//        }
//
//        public static Double RootMeanSquare(this IEnumerable<Double> source)
//        {
//        }
//        public static Double? RootMeanSquare(this IEnumerable<Double?> source)
//        {
//        }
//        public static Decimal RootMeanSquare(this IEnumerable<Decimal> source)
//        {
//        }
//        public static Decimal? RootMeanSquare(this IEnumerable<Decimal?> source)
//        {
//        }
//    }
}


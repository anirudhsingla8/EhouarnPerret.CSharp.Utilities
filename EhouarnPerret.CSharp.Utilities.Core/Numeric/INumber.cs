//
// INumericalOperations.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public interface INumber<T> : IComparable<T>, IEquatable<T>
    {
        void Add(T value);
        void Substract (T value);
        void Divide (T value);
        void Multiply (T value);
        void Modulo (T value);

        T Max { get; }
        T Min { get; }

		T Epsilon { get; }
    }


//
//	public struct NumberInt32 : INumber<NumberInt32>
//	{
//		private Int32 Int32 { get; }
//
//		public NumberInt32(NumberInt32 value)
//		{
//			this.Int32 = value.Int32;
//		}
//		public NumberInt32(Int32 value)
//		{
//			this.Int32 = value;
//		}
//
//		#region INumber Implementation
//		public NumberInt32 Add (NumberInt32 left, NumberInt32 right)
//		{
//			return left.Int32 + right.Int32;
//		}
//		public NumberInt32 Substract (NumberInt32 left, NumberInt32 right)
//		{
//			return left.Int32 - right.Int32;
//		}
//		public NumberInt32 Divide (NumberInt32 left, NumberInt32 right)
//		{
//			return left.Int32 / right.Int32;
//		}
//		public NumberInt32 Multiply (NumberInt32 left, NumberInt32 right)
//		{
//			return left.Int32 * right.Int32;
//		}
//		public NumberInt32 Modulo (NumberInt32 left, NumberInt32 right)
//		{
//			return left.Int32 % right.Int32;
//		}
//
//		public NumberInt32 Max 
//		{
//			get 
//			{
//				return Int32.MaxValue;
//			}
//		}
//		public NumberInt32 Min 
//		{
//			get 
//			{
//				return Int32.MinValue;
//			}
//		}
//		public NumberInt32 Epsilon 
//		{
//			get 
//			{
//				return NumberInt32._epsilon;
//			}
//		}
//
//		private const Int32 _epsilon = 1;
//
//		#endregion
//
//		#region IEquatable Implementation
//		public Boolean Equals (NumberInt32 other)
//		{
//			throw new NotImplementedException ();
//		}
//		#endregion
//
//		#region IComparable implementation
//		public Int32 CompareTo (NumberInt32 other)
//		{
//			throw new NotImplementedException ();
//		}
//		#endregion
//
//
//	}

}

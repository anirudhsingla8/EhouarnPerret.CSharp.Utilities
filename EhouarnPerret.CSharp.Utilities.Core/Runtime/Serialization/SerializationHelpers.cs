//
// SerializationHelpers.cs
//
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
//
// Copyright (c) 2016 
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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Script.Serialization;

namespace EhouarnPerret.CSharp.Utilities.Core.Runtime.Serialization
{
    public static class SerializationExtensions
    {
        public static Byte[] ToBinary<T>(this T value)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(memoryStream, value);

                memoryStream.Position = 0;

                var bytes = memoryStream.ToArray();

                return bytes;
            }
        }
        public static T ToValue<T>(this Byte[] source)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();

                var value = (T)binaryFormatter.Deserialize(memoryStream);

                return value;
            }
        }

//    
//        public static String ToXml<T>(this T value)
//        {
//            
//        }
//        public static String ToJson<T>(this T value)
//        {
//            var javaScriptSerializer = new JavaScriptSerializer();
//            return javaScriptSerializer.Serialize(value);
//        }
//        public static T ToValue<T>(this String value)
//        {
//        }
    }
}
    
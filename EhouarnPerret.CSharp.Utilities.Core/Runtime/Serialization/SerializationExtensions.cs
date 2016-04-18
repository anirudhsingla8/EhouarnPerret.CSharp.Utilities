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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace EhouarnPerret.CSharp.Utilities.Core.Runtime.Serialization
{
    public static class SerializationExtensions
    {
        public static void SerializeToXmlFile<T>(this T value, String path)
            where T : new()
        {
            value.SerializeToXml().WriteToFile(path);
        }
        public static void SerializeToJsonFile<T>(this T value, String path)
            where T : new()
        {
            value.SerializeToJson().WriteToFile(path);
        }

        public static T DeserializeXmlFile<T>(this String path)
            where T : new()
        {
            return path.ReadTextFromFile().DeserializeXml<T>();
        }
        public static T DeserializeJsonFile<T>(this String path)
            where T : new()
        {
            return path.ReadTextFromFile().DeserializeJson<T>();
        }

        private static DataContractSerializerSettings XmlSerializerSettings { get; }
        = new DataContractSerializerSettings()
        {
            PreserveObjectReferences = true,
            SerializeReadOnlyTypes = true,
        };

        private static DataContractJsonSerializerSettings JsonSerializerSettings { get; }
        = new DataContractJsonSerializerSettings
        {
            SerializeReadOnlyTypes = true,
        };

        public static String SerializeToXml<T>(this T value)
            where T : new()
        {
            var dataContractSerializer = new DataContractSerializer(typeof(T), SerializationExtensions.XmlSerializerSettings);

            using (var stringWriter = new StringWriter())
            {
//                var xmlWriterSettings = new XmlWriterSettings();
//                xmlWriterSettings.Indent = true;
//                xmlWriterSettings.IndentChars = "\t";
//                xmlWriterSettings.OmitXmlDeclaration = true;
//
//                using (var xmlWriter = XmlTextWriter.Create(stringWriter, xmlWriterSettings))
//                {
//                    dataContractSerializer.WriteObject(xmlWriter, value);
//
//                    xmlWriter.Flush();
//
//                    return stringWriter.ToString();
//                }

                using (var xmlTextWriter = new XmlTextWriter(stringWriter))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlTextWriter.IndentChar = '\t';
                    xmlTextWriter.Indentation = 1;

                    dataContractSerializer.WriteObject(xmlTextWriter, value);

                    return stringWriter.ToString();
                }
            }
        }
        public static String SerializeToJson<T>(this T value)
            where T : new()
        {
            var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T), SerializationExtensions.JsonSerializerSettings);
           
            using (var memoryStream = new MemoryStream())
            {
                using(var jsonWriter = JsonReaderWriterFactory.CreateJsonWriter(memoryStream))
                {
                    dataContractJsonSerializer.WriteObject(jsonWriter, value);

                    jsonWriter.Flush();

                    return Encoding.Default.GetString(memoryStream.ToArray());
                }
            }
        }

        public static T DeserializeXml<T>(this String value)
            where T : new()
        {
            var dataContractSerializer = new DataContractSerializer(typeof(T), SerializationExtensions.XmlSerializerSettings);

            using (var stringReader = new StringReader(value))
            {
                using (var xmlTextReader = new XmlTextReader(stringReader))
                {
                     return (T)dataContractSerializer.ReadObject(xmlTextReader);
                }
            }
        }
        public static T DeserializeJson<T>(this String value)
            where T : new()
        {
            var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T), SerializationExtensions.JsonSerializerSettings);

            using (var memoryStream = new MemoryStream(Encoding.Default.GetBytes(value)))
            {
               return (T)dataContractJsonSerializer.ReadObject(memoryStream);
            }
        }
    
        //        public static void SerializeToBinaryFile<T>(this T value, String path)
        //        {
        //            value.SerializeToBinary().WriteToFile(path);
        //        }
        //        public static T DeserializeBinaryFile<T>(this String path)
        //        {
        //            return path.ReadBytesFromFile().DeserializeBinary<T>();
        //        }
        //        public static T DeserializeBinary<T>(this Byte[] source)
        //        {
        //            var dataContractSerializer = new DataContractSerializer(typeof(T));
        //
        //            using (var memoryStream = new MemoryStream(source))
        //            {
        //                using (var binaryReader = new BinaryReader(memoryStream))
        //                {
        //                    return (T)dataContractSerializer.ReadObject(memoryStream);
        //                }
        //            }
        //        }
        //        public static Byte[] SerializeToBinary<T>(this T value)
        //        {
        //            var dataContractSerializerSettings = new DataContractSerializerSettings()
        //            {
        //                PreserveObjectReferences = true,
        //                SerializeReadOnlyTypes = true,
        //            };
        //
        //            var dataContractSerializer = new DataContractSerializer(typeof(T), dataContractSerializerSettings);
        //
        //            using (var memoryStream = new MemoryStream())
        //            {
        //                using (var binaryWriter = new BinaryWriter(memoryStream))
        //                {
        //                    dataContractSerializer.WriteObject(memoryStream, value);
        //
        //                    return memoryStream.ToArray();
        //                }
        //            }
        //        }
    }
}
    
//
// Program.cs
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
using System.Collections.Generic;
using EhouarnPerret.CSharp.Utilities.Core.Patterns.Design.Command;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Dynamic;
using System.Configuration;
using EhouarnPerret.CSharp.Utilities.Core.Linq;
using System.Xml.Serialization;
using EhouarnPerret.CSharp.Utilities.Core.Runtime.Serialization;
using EhouarnPerret.CSharp.Utilities.Core.Collections.Generic;
using EhouarnPerret.CSharp.Utilities.Core;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace EhouarnPerret.CSharp.Utilities.Sandbox
{
    public static class Program
    {
        public static void Main(params String[] arguments)
        {
//            var undoRedoManager = new UndoRedoManager();
//
//            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do"), () => Console.WriteLine(@"Undo"));
//            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do1"), () => Console.WriteLine(@"Undo1"));
//            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do2"), () => Console.WriteLine(@"Undo2"));
//            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do3"), () => Console.WriteLine(@"Undo3"));
//            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do4"), () => Console.WriteLine(@"Undo4"));
//
//            undoRedoManager.Undo(2);
//            undoRedoManager.Redo();
//            undoRedoManager.Redo();
//            undoRedoManager.Undo(2);
//
//            undoRedoManager.Redo();
//            undoRedoManager.Redo();
//            undoRedoManager.Redo();

            var path = @"Configuration.xml";

            var configuration = new Configuration();

            configuration.TestMode.SensorInterfaces.Add(new SingleStateMessageBasedFunctionConfiguration(42, "Michelle"));

            configuration.SerializeToXmlFile(path);

            path.ReadTextFromFile().WriteLineToConsole();

            var restoredConfiguration = path.DeserializeXmlFile<Configuration>();

            Console.ReadKey();
        }


        public class IdentifiableKeyedCollection<TItem> : System.Collections.ObjectModel.KeyedCollection<Byte, TItem>
            where TItem : IIdentifiable
        {
            public IdentifiableKeyedCollection()
            {
            }

            public IdentifiableKeyedCollection(IEnumerable<TItem> items)
            {
                foreach (var item in items) 
                {
                    this.Add(item);
                }
            }

            protected override Byte GetKeyForItem(TItem item)
            {
                return item.Id;
            }
        }

        [DataContract]
        public class Configuration
        {
            public Configuration()
            {
                this.TestMode = new TestModeConfiguration();
            }

            [DataMember]
            public UInt32 TesterId { get; set; } 

            [DataMember]
            public UInt32 EcuId { get; set; }

            [DataMember]
            public TestModeConfiguration TestMode { get; private set; }
        }

        [DataContract]
        public class TestModeConfiguration
        {
            public TestModeConfiguration()
            {
                this.SensorInterfaces = new IdentifiableKeyedCollection<SingleStateMessageBasedFunctionConfiguration>();
            }

            [DataMember]
            public ReadOnlyCollection<Byte> InitializationFrame { get; set; }
        
            [DataMember]
            public IdentifiableKeyedCollection<SingleStateMessageBasedFunctionConfiguration> SensorInterfaces { get; private set; }

            [DataMember]
            public IdentifiableKeyedCollection<SingleStateMessageBasedFunctionConfiguration> DigitalInputs { get; private set; }

            [DataMember]
            public IdentifiableKeyedCollection<SingleStateMessageBasedFunctionConfiguration> FrequencyInputs { get; private set; }

            [DataMember]
            public IdentifiableKeyedCollection<SingleStateMessageBasedFunctionConfiguration> AdcData { get; private set; }

              
        }

        public interface INamable
        {
            String Name { get; }
        }

        public interface IIdentifiable
        {
            Byte Id { get; }
        }

        public interface IFunctionConfiguration : IIdentifiable, INamable
        {
        }

        [DataContract]
        public struct LinearTransformation
        {
            public LinearTransformation(Single a, Single b)
            {
                if ((a == 0.0f))
                {
                    throw new ArgumentOutOfRangeException(nameof(a));
                }
                else
                {
                    this.A = a;
                    this.B = b;
                }
            }

            [DataMember]
            public Single A { get; private set; }

            [DataMember]
            public Single B { get; private set; }

            public static LinearTransformation Constant { get; } = new LinearTransformation(1.0f, 0.0f);
        }

        public interface ISupportLinearTransformation
        {
            LinearTransformation Transformation { get; }
        }

        public interface ISingleStateMessageBasedFunctionConfiguration : IFunctionConfiguration, ISupportLinearTransformation
        {
            Byte[] Activation { get; }
        }

        public interface IDoubleStateMessageBasedFunctionConfiguration : ISingleStateMessageBasedFunctionConfiguration
        {
            Byte[] Deactivation { get; }
        }

        [DataContract]
        public abstract class FunctionConfiguration : IFunctionConfiguration
        {
            protected FunctionConfiguration()
            {
            }

            protected FunctionConfiguration(Byte id, String name)
            {
                this.Id = id;
                this.Name = name;
            }

            #region IIdentifiable Implementation
            [DataMember]
            public Byte Id { get; private set; }
            #endregion

            #region INamable Implementation
            [DataMember]
            public String Name { get; private set; }
            #endregion
        }

        [DataContract]
        public class SingleStateMessageBasedFunctionConfiguration : FunctionConfiguration, ISingleStateMessageBasedFunctionConfiguration
        {
            public SingleStateMessageBasedFunctionConfiguration()
            {
            }

            public SingleStateMessageBasedFunctionConfiguration(Byte id, String name)
                : base(id, name)
            {
                this.Transformation = LinearTransformation.Constant;
            }

            public SingleStateMessageBasedFunctionConfiguration(Byte id, String name, LinearTransformation transformation)
                : base(id, name)
            {
                this.Transformation = transformation;
            }

            public SingleStateMessageBasedFunctionConfiguration(Byte id, String name, Single transformationA = 1, Single transformationB = 0)
                : base(id, name)
            {
                this.Transformation = new LinearTransformation(transformationA, transformationB);
            }

            #region ISingleStateMessageBasedFunctionConfiguration Implementation
            [DataMember]
            public Byte[] Activation { get; private set; }
            #endregion

            #region ISupportLinearTransformation Implementation
            [DataMember]
            public LinearTransformation Transformation { get; private set; }
            #endregion
        }

        [DataContract]
        public class DoubleStateMessageBasedFunctionConfiguration : SingleStateMessageBasedFunctionConfiguration, IDoubleStateMessageBasedFunctionConfiguration
        {
            public DoubleStateMessageBasedFunctionConfiguration()
            {
            }

            public DoubleStateMessageBasedFunctionConfiguration(Byte id, String name)
                : base(id, name)
            {
            }

            public DoubleStateMessageBasedFunctionConfiguration(Byte id, String name, LinearTransformation transformation)
                : base(id, name, transformation)
            {
            }

            #region IDoubleStateMessageBasedFunctionConfiguration Implementation
            [DataMember]
            public Byte[] Deactivation { get; private set; }
            #endregion
        }

        [DataContract]
        public class ApplicationConfiguration
        {
     
        }

        public enum BusKind : byte
        {
            Can = 0x00,
            Kline = 0x01,
        }

        public enum SensorKind : byte
        {
            Analog = 0x00,
            Digital = 0x01,
        }


//        public class LoadControlConfiguration
//        {
//            
//        }
//
//        public class LoadConfiguration
//        {
//            public Single DutyCycle { get; set; }
//            public Single Frequency { get; set; }
//            public Single Voltage { get; set; }
//        }
//
//        public struct LinearTransformation
//        {
//            public LinearTransformation(Single a, Single b)
//            {
//                this.A = a;
//                this.B = b;
//            }
//
//            public Single A { get; }
//
//            public Single B { get; }
//        }
//
//        public class FrequencyInputConfiguration : ISupportLinearTransformation
//        {
//            public FrequencyInputConfiguration()
//            {
//            }
//
//            public Byte Id { get; }
//
//            public Single Frequency { get; }
//
//            public LinearTransformation LinearTransformation { get; }
//        }
//
//        public class SensorInterfaceConfiguration
//        {
//
//        }
//        public class AdcDataConfiguration
//        {
//
//        }
//        public class DigitalInputConfiguration
//        {
//
//        }
//        public class ReadIdConfiguration
//        {
//        }
//        public class RelayPowerConfiguration
//        {
//        }
//        public class MotorFunctionConfiguration
//        {
//        }
//        public class MotorCurrentConfiguration
//        {
//        }
//        public class ReservedFunctionsConfiguration
//        {
//        }
//        public class EpRomConfiguration
//        {
//        }
//        public class FlashCommandConfiguration
//        {
//            
//        }

//        private static void HeapPermutation<T>(IList<T> source, Int32 n)
//        {
//            // Console.Write(" n = {0} => ", n);
//
//            if (n == 1)
//            {
//                Console.WriteLine(String.Join(@" ", source));
//            }
//            else
//            {
//                for (var i = 0; i < n; i++)
//                {
//                    Program.HeapPermutation(source, n - 1);
//
//                    var index = ((i % 2) == 0) ? i : 0;
//
//                    Program.Swap(source, i, n - 1);
//                }
//            }
//        }
//
//        private static void Swap<T>(IList<T> source, Int32 index1, Int32 index2)
//        {
//            var tmp = source[index1];
//            source[index1] = source[index2];
//            source[index2] = tmp;
//        }
    }
}

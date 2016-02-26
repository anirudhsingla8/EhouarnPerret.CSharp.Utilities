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
using System.Collections.ObjectModel;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Web.Script.Serialization;
using System.Xml.Schema;
using System.Xml.Serialization;
using EhouarnPerret.CSharp.Utilities.Core;
using EhouarnPerret.CSharp.Utilities.Core.Collections.Generic;
using EhouarnPerret.CSharp.Utilities.Core.Linq;
using EhouarnPerret.CSharp.Utilities.Core.Patterns.Design.Command;
using EhouarnPerret.CSharp.Utilities.Core.Runtime.Serialization;

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

            for (Byte i = 0; i < 2; i++)
            {
                var item = new TransformableSingleStateMessageBasedFunctionConfiguration(i, @"F" + i);
                configuration.TestMode.FrequencyInputs.Add(item);
            }

            for (Byte i = 0; i < 6; i++)
            {
                var item = new TransformableSingleStateMessageBasedFunctionConfiguration(i, i.ToString(@"X2"));
                configuration.TestMode.SensorInterfaces.Add(item);
            }

            for (Byte i = 0; i < 16; i++)
            {
                var item = new TransformableSingleStateMessageBasedFunctionConfiguration(i, @"S" + i);
                configuration.TestMode.AdcData.Add(item);
            }

            for (Byte i = 0; i < 2; i++)
            {
                var item = new TransformableSingleStateMessageBasedFunctionConfiguration(i, @"D" + i);
                configuration.TestMode.DigitalInputs.Add(item);
            }

            configuration.TestMode.ReadIds.Add(new SingleStateMessageBasedFunctionConfiguration(0, @"Software Id"));
            configuration.TestMode.ReadIds.Add(new SingleStateMessageBasedFunctionConfiguration(1, @"Hardware Id"));
            configuration.TestMode.ReadIds.Add(new SingleStateMessageBasedFunctionConfiguration(2, @"Boot Id"));
            configuration.TestMode.ReadIds.Add(new SingleStateMessageBasedFunctionConfiguration(3, @"Calibration Id"));
            configuration.TestMode.ReadIds.Add(new SingleStateMessageBasedFunctionConfiguration(4, @"TMSW Id"));

            for (Byte i = 0; i < 3; i++)
            {
                // configuration.TestMode.RelayPowers.Add(new DoubleStateMessageBasedFunctionConfiguration(i, ))
            }


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
            public DateTime Creation { get; private set; }

            [DataMember]
            public DateTime LastModification { get; private set; }

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
                this.SensorInterfaces = new IdentifiableKeyedCollection<TransformableSingleStateMessageBasedFunctionConfiguration>();
                this.DigitalInputs = new IdentifiableKeyedCollection<TransformableSingleStateMessageBasedFunctionConfiguration>();
                this.FrequencyInputs = new IdentifiableKeyedCollection<TransformableSingleStateMessageBasedFunctionConfiguration>();
                this.AdcData = new IdentifiableKeyedCollection<TransformableSingleStateMessageBasedFunctionConfiguration>();
                this.ReadIds = new IdentifiableKeyedCollection<SingleStateMessageBasedFunctionConfiguration>();

                this.RelayPowers = new IdentifiableKeyedCollection<DoubleStateMessageBasedFunctionConfiguration>();
                this.Motor = new IdentifiableKeyedCollection<DoubleStateMessageBasedFunctionConfiguration>();
                this.MotorCurrent = new IdentifiableKeyedCollection<TransformableDoubleStateMessageBasedFunctionConfiguration>();
                this.Reserved = new IdentifiableKeyedCollection<DoubleStateMessageBasedFunctionConfiguration>();
            }

            [DataMember]
            public ReadOnlyCollection<Byte> InitializationFrame { get; set; }
        
            [DataMember]
            public IdentifiableKeyedCollection<TransformableSingleStateMessageBasedFunctionConfiguration> SensorInterfaces { get; private set; }

            [DataMember]
            public IdentifiableKeyedCollection<TransformableSingleStateMessageBasedFunctionConfiguration> DigitalInputs { get; private set; }

            [DataMember]
            public IdentifiableKeyedCollection<TransformableSingleStateMessageBasedFunctionConfiguration> FrequencyInputs { get; private set; }

            [DataMember]
            public IdentifiableKeyedCollection<TransformableSingleStateMessageBasedFunctionConfiguration> AdcData { get; private set; }
        
            [DataMember]
            public IdentifiableKeyedCollection<SingleStateMessageBasedFunctionConfiguration> ReadIds { get; private set; }
        
            [DataMember]
            public IdentifiableKeyedCollection<DoubleStateMessageBasedFunctionConfiguration> RelayPowers { get; private set; }

            [DataMember]
            public IdentifiableKeyedCollection<DoubleStateMessageBasedFunctionConfiguration> Motor { get; private set; }
         
            [DataMember]
            public IdentifiableKeyedCollection<TransformableDoubleStateMessageBasedFunctionConfiguration> MotorCurrent { get; private set; }

            [DataMember]
            public IdentifiableKeyedCollection<DoubleStateMessageBasedFunctionConfiguration> Reserved { get; private set; }
        }

        public interface INamable
        {
            String Name { get; }
        }

        public interface IIdentifiable
        {
            Byte Id { get; }
        }

        public interface INamableIdentifiable : IIdentifiable, INamable
        {
        }

        public abstract class NamableIdentifiable : INamableIdentifiable
        {
            #region INamable Implementation
            public string Name { get; }
            #endregion
            #region IIdentifiable implementation
            public byte Id
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
            #endregion
            
        }

        public interface ISupportLinearTransformation
        {
            LinearTransformation Transformation { get; }
        }

        public interface ISingleStateMessageBasedFunctionConfiguration : INamableIdentifiable
        {
            ReadOnlyCollection<Byte> Activation { get; set; }
        }

        public interface IDoubleStateMessageBasedFunctionConfiguration : ISingleStateMessageBasedFunctionConfiguration
        {
            ReadOnlyCollection<Byte> Deactivation { get; set; }
        }

        public interface ILinearTransformation
        {
            Single A { get; set; }
            Single B { get; set; }
        }

        [DataContract]
        public struct LinearTransformation : ILinearTransformation
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
            public Single A { get; set; }

            [DataMember]
            public Single B { get; set; }

            public static LinearTransformation Constant { get; } = new LinearTransformation(1.0f, 0.0f);
        }

        [DataContract]
        public abstract class FunctionConfiguration : INamableIdentifiable
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
        public class SingleStateMessageBasedFunctionConfiguration : TransformableFunctionConfiguration, ISingleStateMessageBasedFunctionConfiguration
        {
            public SingleStateMessageBasedFunctionConfiguration()
            {
            }

            public SingleStateMessageBasedFunctionConfiguration(Byte id, String name)
                : base(id, name)
            {
            }

            public SingleStateMessageBasedFunctionConfiguration(Byte id, String name, IEnumerable<Byte> activation)
                : base(id, name)
            {
                this.Activation = new ReadOnlyCollection<Byte>(activation.ToList());
            }

            #region ISingleStateMessageBasedFunctionConfiguration Implementation
            [DataMember]
            public ReadOnlyCollection<Byte> Activation { get; set; }
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

            public DoubleStateMessageBasedFunctionConfiguration(Byte id, String name, IEnumerable<Byte> activation, IEnumerable<Byte> deactivation)
                : base(id, name, activation)
            {
                this.Deactivation = new ReadOnlyCollection<Byte>(deactivation.ToList());
            }

            #region IDoubleStateMessageBasedFunctionConfiguration Implementation
            [DataMember]
            public ReadOnlyCollection<Byte> Deactivation { get; set; }
            #endregion
        }

        [DataContract]
        public abstract class TransformableFunctionConfiguration : FunctionConfiguration, ISupportLinearTransformation
        {
            protected TransformableFunctionConfiguration()
            {
            }

            public TransformableFunctionConfiguration(Byte id, String name, LinearTransformation transformation)
                : base(id, name)
            {
                this.Transformation = transformation;
            }

            public TransformableFunctionConfiguration(Byte id, String name, Single transformationA = 1, Single transformationB = 0)
                : this(id, name, new LinearTransformation(transformationA, transformationB))
            {
            }

            #region ISupportLinearTransformation Implementation
            [DataMember]
            public LinearTransformation Transformation { get; set; }
            #endregion
        }

        [DataContract]
        public class TransformableSingleStateMessageBasedFunctionConfiguration : TransformableFunctionConfiguration, ISingleStateMessageBasedFunctionConfiguration
        {
            public TransformableSingleStateMessageBasedFunctionConfiguration()
            {
            }

            public TransformableSingleStateMessageBasedFunctionConfiguration(Byte id, String name, Single transformationA = 1, Single transformationB = 0, ReadOnlyCollection<Byte> activation = null)
                : base(id, name, transformationA, transformationB)
            {
                this.Activation = activation;
            }

            public TransformableSingleStateMessageBasedFunctionConfiguration(Byte id, String name, LinearTransformation transformation, ReadOnlyCollection<Byte> activation = null)
                : base(id, name, transformation)
            {
                this.Activation = activation;
            }

          

            #region ISingleStateMessageBasedFunctionConfiguration Implementation
            [DataMember]
            public ReadOnlyCollection<Byte> Activation { get; set; }
            #endregion
        }

        [DataContract]
        public class TransformableDoubleStateMessageBasedFunctionConfiguration : TransformableSingleStateMessageBasedFunctionConfiguration, IDoubleStateMessageBasedFunctionConfiguration
        {
            public TransformableDoubleStateMessageBasedFunctionConfiguration()
            {
            }

            public TransformableDoubleStateMessageBasedFunctionConfiguration(Byte id, String name, LinearTransformation transformation, ReadOnlyCollection<Byte> activation = null, ReadOnlyCollection<Byte> deactivation = null)
                : base(id, name, transformation, activation)
            {
                this.Deactivation = deactivation;
            }

            public TransformableDoubleStateMessageBasedFunctionConfiguration(Byte id, String name, Single transformationA = 1, Single transformationB = 0,  ReadOnlyCollection<Byte> activation = null, ReadOnlyCollection<Byte> deactivation = null)
                : base(id, name, transformationA, transformationB, activation)
            {
                this.Deactivation = deactivation;
            }

            #region IDoubleStateMessageBasedFunctionConfiguration Implementation
            [DataMember]
            public ReadOnlyCollection<Byte> Deactivation { get; set; }
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

        public interface IDescriptable
        {
            String Description { get; set; }
        }

        public class ErrorCode : INamableIdentifiable
        {
            #region IIdentifiable Implementation
            public Byte Id
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
            #endregion

            #region INamable Implementation
            public string Name
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
            #endregion
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

﻿//
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
using System.Drawing.Printing;

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
                var item = new TransformableSingleStateMessageBasedFunctionConfiguration(@"F" + i);
                configuration.TestMode.FrequencyInputs.Add(item);
            }

            for (Byte i = 0; i < 6; i++)
            {
                var item = new TransformableSingleStateMessageBasedFunctionConfiguration(i.ToString(@"X2"));
                configuration.TestMode.SensorInterfaces.Add(item);
            }

            for (Byte i = 0; i < 16; i++)
            {
                var item = new TransformableSingleStateMessageBasedFunctionConfiguration(@"S" + i);
                configuration.TestMode.AdcData.Add(item);
            }

            for (Byte i = 0; i < 2; i++)
            {
                var item = new TransformableSingleStateMessageBasedFunctionConfiguration(@"D" + i);
                configuration.TestMode.DigitalInputs.Add(item);
            }

            configuration.TestMode.ReadIds.Add(new SingleStateMessageBasedFunctionConfiguration(@"Software Id"));
            configuration.TestMode.ReadIds.Add(new SingleStateMessageBasedFunctionConfiguration(@"Hardware Id"));
            configuration.TestMode.ReadIds.Add(new SingleStateMessageBasedFunctionConfiguration(@"Boot Id"));
            configuration.TestMode.ReadIds.Add(new SingleStateMessageBasedFunctionConfiguration(@"Calibration Id"));
            configuration.TestMode.ReadIds.Add(new SingleStateMessageBasedFunctionConfiguration(@"TMSW Id"));

            for (Byte i = 0; i < 3; i++)
            {
                configuration.TestMode.RelayPowers.Add(new DoubleStateMessageBasedFunctionConfiguration(@"RP" + i));
            }

            for (Byte i = 0; i < 3; i++)
            {
                configuration.TestMode.Motor.Add(new DoubleStateMessageBasedFunctionConfiguration(@"M" + i));
            }

            configuration.SerializeToXmlFile(path);

            path.ReadTextFromFile().WriteLineToConsole();

            var restoredConfiguration = path.DeserializeXmlFile<Configuration>();

            Console.ReadKey();
        }

//        public class IdentifiableKeyedCollection<TItem> : System.Collections.ObjectModel.KeyedCollection<Byte, TItem>
//            where TItem : IIdentifiable
//        {
//            public IdentifiableKeyedCollection()
//            {
//            }
//
//            public IdentifiableKeyedCollection(IEnumerable<TItem> items)
//            {
//                foreach (var item in items) 
//                {
//                    this.Add(item);
//                }
//            }
//
//            protected override Byte GetKeyForItem(TItem item)
//            {
//                return item.Id;
//            }
//        }
//

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
                this.SensorInterfaces = new List<TransformableSingleStateMessageBasedFunctionConfiguration>();
                this.DigitalInputs = new List<TransformableSingleStateMessageBasedFunctionConfiguration>();
                this.FrequencyInputs = new List<TransformableSingleStateMessageBasedFunctionConfiguration>();
                this.AdcData = new List<TransformableSingleStateMessageBasedFunctionConfiguration>();
                this.ReadIds = new List<SingleStateMessageBasedFunctionConfiguration>();

                this.RelayPowers = new List<DoubleStateMessageBasedFunctionConfiguration>();
                this.Motor = new List<DoubleStateMessageBasedFunctionConfiguration>();
                this.MotorCurrent = new List<TransformableDoubleStateMessageBasedFunctionConfiguration>();
                this.Reserved = new List<DoubleStateMessageBasedFunctionConfiguration>();

                this.EpRom = new DoubleStateMessageBasedFunctionConfiguration();
                this.Flash = new SingleStateMessageBasedFunctionConfiguration();
            }

            [DataMember]
            public ReadOnlyCollection<Byte> InitializationFrame { get; set; }
        
            [DataMember]
            public List<TransformableSingleStateMessageBasedFunctionConfiguration> SensorInterfaces { get; private set; }

            [DataMember]
            public List<TransformableSingleStateMessageBasedFunctionConfiguration> DigitalInputs { get; private set; }

            [DataMember]
            public List<TransformableSingleStateMessageBasedFunctionConfiguration> FrequencyInputs { get; private set; }

            [DataMember]
            public List<TransformableSingleStateMessageBasedFunctionConfiguration> AdcData { get; private set; }
        
            [DataMember]
            public List<SingleStateMessageBasedFunctionConfiguration> ReadIds { get; private set; }
        
            [DataMember]
            public List<DoubleStateMessageBasedFunctionConfiguration> RelayPowers { get; private set; }

            [DataMember]
            public List<DoubleStateMessageBasedFunctionConfiguration> Motor { get; private set; }
         
            [DataMember]
            public List<TransformableDoubleStateMessageBasedFunctionConfiguration> MotorCurrent { get; private set; }

            [DataMember]
            public List<DoubleStateMessageBasedFunctionConfiguration> Reserved { get; private set; }
        
            [DataMember]
            public DoubleStateMessageBasedFunctionConfiguration EpRom { get; private set; }

            [DataMember]
            public SingleStateMessageBasedFunctionConfiguration Flash { get; private set; }
        }

        public interface INamable
        {
            String Name { get; set; }
        }

        [DataContract]
        public abstract class Namable : INamable
        {
            protected Namable(String name = @"")
            {
                this.Name = name;
            }

            #region INamable Implementation
            [DataMember]
            public String Name { get; set; }
            #endregion
        }

        public interface IIdentifiable : IIdentifiable<Byte>
        {
        }

        public interface IIdentifiable<TId>
            where TId : struct
        {
            TId Id { get; set; }
        }

        [DataContract]
        public abstract class IdentifiableNamable<TId> : Namable, IIdentifiableNamable<TId>
            where TId : struct
        {
            public IdentifiableNamable(String name = @"", TId id = default(TId))
                : base(name)
            {
                this.Id = id;
            }

            #region IIdentifiable Implementation
            [DataMember]
            public TId Id { get; set; }
            #endregion
        }

        public interface IIdentifiableNamable : INamable, IIdentifiable
        {
            
        }

        public interface IIdentifiableNamable<TId> : INamable, IIdentifiable<TId>
            where TId : struct
        {

        }

        [DataContract]
        public abstract class IdentifiableNamable : Namable, IIdentifiableNamable
        {
            public IdentifiableNamable(String name = @"", Byte id = 0x00)
                : base(name)
            {
                this.Id = id;
            }

            #region IIdentifiable Implementation
            [DataMember]
            public Byte Id { get; set; }
            #endregion
        }

        public interface ISupportLinearTransformation
        {
            LinearTransformation Transformation { get; }
        }

        public interface ISingleStateMessageBasedFunctionConfiguration : INamable
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
        public abstract class FunctionConfiguration : Namable
        {
            protected FunctionConfiguration(String name = @"")
            {
                this.Name = name;
            }

            #region INamable Implementation
            [DataMember]
            public String Name { get; private set; }
            #endregion
        }

        [DataContract]
        public class SingleStateMessageBasedFunctionConfiguration : TransformableFunctionConfiguration, ISingleStateMessageBasedFunctionConfiguration
        {
            public SingleStateMessageBasedFunctionConfiguration(String name = @"", IEnumerable<Byte> activation = null)
                : base(name)
            {
                if (activation != null)
                {
                    this.Activation = new ReadOnlyCollection<Byte>(activation.ToList());
                }
            }

            #region ISingleStateMessageBasedFunctionConfiguration Implementation
            [DataMember]
            public ReadOnlyCollection<Byte> Activation { get; set; }
            #endregion
        }

        [DataContract]
        public class DoubleStateMessageBasedFunctionConfiguration : SingleStateMessageBasedFunctionConfiguration, IDoubleStateMessageBasedFunctionConfiguration
        {
            public DoubleStateMessageBasedFunctionConfiguration(String name = @"", IEnumerable<Byte> activation = null, IEnumerable<Byte> deactivation = null)
                : base(name, activation)
            {
                if (deactivation != null)
                {
                    this.Deactivation = new ReadOnlyCollection<Byte>(deactivation.ToList());
                }
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

            public TransformableFunctionConfiguration(LinearTransformation transformation, String name = @"")
                : base(name)
            {
                this.Transformation = transformation;
            }

            public TransformableFunctionConfiguration(String name = @"", Single transformationA = 1, Single transformationB = 0)
                : this(new LinearTransformation(transformationA, transformationB), name)
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
            public TransformableSingleStateMessageBasedFunctionConfiguration(String name = @"", Single transformationA = 1, Single transformationB = 0, ReadOnlyCollection<Byte> activation = null)
                : base(name, transformationA, transformationB)
            {
                this.Activation = activation;
            }

            public TransformableSingleStateMessageBasedFunctionConfiguration(LinearTransformation transformation, String name = @"", ReadOnlyCollection<Byte> activation = null)
                : base(transformation, name)
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
            public TransformableDoubleStateMessageBasedFunctionConfiguration(String name = @"", Single transformationA = 1, Single transformationB = 0,  ReadOnlyCollection<Byte> activation = null, ReadOnlyCollection<Byte> deactivation = null)
                : base(name, transformationA, transformationB, activation)
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

        public interface IErrorCode : IIdentifiableNamable, IDescriptable
        {
        }

        public class ErrorCode : IdentifiableNamable, IErrorCode
        {
            public ErrorCode(Byte id = 0x00, String name = @"", String description = @"")
                : base(name, id)
            {
                this.Description = description;
            }

            #region IDescriptable implementation
            public String Description { get; set; }
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

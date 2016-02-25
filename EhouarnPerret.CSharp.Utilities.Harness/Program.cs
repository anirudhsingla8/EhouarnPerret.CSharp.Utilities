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

namespace EhouarnPerret.CSharp.Utilities.Sandbox
{
    public static class Program
    {
        public static void Main(params String[] arguments)
        {
            var undoRedoManager = new UndoRedoManager();

            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do"), () => Console.WriteLine(@"Undo"));
            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do1"), () => Console.WriteLine(@"Undo1"));
            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do2"), () => Console.WriteLine(@"Undo2"));
            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do3"), () => Console.WriteLine(@"Undo3"));
            undoRedoManager.AddExecute(() => Console.WriteLine(@"Do4"), () => Console.WriteLine(@"Undo4"));

            undoRedoManager.Undo(2);
            undoRedoManager.Redo();
            undoRedoManager.Redo();
            undoRedoManager.Undo(2);

            undoRedoManager.Redo();
            undoRedoManager.Redo();
            undoRedoManager.Redo();

            var configuration = new Configuration();

            var configurationPath = @"Configuration.xml";

            configuration.EcuId = 0x742;
            configuration.TesterId = 0x743;
            configuration.TestMode.InitializationFrame = new Byte[] { 0x42, 0x69, 0x78 };

            configuration.SerializeToXmlFile(configurationPath);

            var re = configurationPath.DeserializeXmlFile<Configuration>();

            Console.ReadKey();
        }
       
        public class Configuration
        {
            public Configuration()
            {
                this.TestMode = new TestModeConfiguration();
                this.Application = new ApplicationConfiguration();
            }

            public UInt16 TesterId { get; set; } 
            public UInt16 EcuId { get; set; }

            public TestModeConfiguration TestMode { get; }
            public ApplicationConfiguration Application { get; }
        }

        public class TestModeConfiguration
        {
            public TestModeConfiguration()
            {
                this.FrequencyInputs = new KeyedCollection<Byte, FrequencyInputConfiguration>(item => item.Id);
            }

            public Byte[] InitializationFrame { get; set; }

            public KeyedCollection<Byte, FrequencyInputConfiguration> FrequencyInputs { get; }
        }

        public class ApplicationConfiguration
        {
            public FrequencyInputConfiguration FrequencyInput { get; }
            public SensorInterfaceConfiguration SensorInterface { get; }
            public AdcDataConfiguration AdcData { get; }
            public DigitalInputConfiguration DigitalInput { get; }
        }

        public interface ISupportLinearTransformation
        {
            LinearTransformation Transformation { get; }
        }

        public class LoadControlConfiguration
        {
            
        }

        public class LoadConfiguration
        {
            public Single DutyCycle { get; set; }
            public Single Frequency { get; set; }
            public Single Voltage { get; set; }
        }

        public struct LinearTransformation
        {
            public LinearTransformation(Single a, Single b)
            {
                this.A = a;
                this.B = b;
            }

            public Single A { get; }
            public Single B { get; }
        }

        public class FrequencyInputConfiguration : ISupportLinearTransformation
        {
            public FrequencyInputConfiguration(Byte id)
            {
                this.Id = id ;   
                this.Transformation = new LinearTransformation();
            }

            public Byte Id { get; }
            public Single Frequency { get; }

            public LinearTransformation Transformation { get; }
        }

        public class SensorInterfaceConfiguration
        {

        }
        public class AdcDataConfiguration
        {

        }
        public class DigitalInputConfiguration
        {

        }
        public class ReadIdConfiguration
        {
        }
        public class RelayPowerConfiguration
        {
        }
        public class MotorFunctionConfiguration
        {
        }
        public class MotorCurrentConfiguration
        {
        }
        public class ReservedFunctionsConfiguration
        {
        }
        public class EpRomConfiguration
        {
        }
        public class FlashCommandConfiguration
        {
            
        }

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

//
//  Copyright 2016  Ehouarn Perret
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
using System.IO.Ports;

namespace EhouarnPerret.CSharp.Utilities.Core.IO.Ports
{
    internal static class SerialPortExtensions
    {
        public static void Write(this SerialPort serialPort, Byte[] data)
        {
            serialPort.Write(data, 0, data.Length);
        }

        public static Byte[] Read(this SerialPort serialPort)
        {
            lock (serialPort)
            {
                var data = default(Byte[]);

                if (serialPort.BytesToRead > 0)
                {
                    data = new Byte[serialPort.BytesToRead];

                    serialPort.Read(data, 0, data.Length);
                }
                else
                {
                    data = new Byte[0];
                }

                return data;
            }
        }
    }
}


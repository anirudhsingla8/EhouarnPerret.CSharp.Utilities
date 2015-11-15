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

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public static class EnvironmentInformation
    {
        static EnvironmentInformation()
        {
            EnvironmentInformation.IsRunningMono = Type.GetType(EnvironmentInformation.MonoRuntimeTypeName) != null;

            // Cheap Trick
            var platformId = (Int32)Environment.OSVersion.Platform;
            EnvironmentInformation.IsUnix = (platformId == 4) || (platformId == 6) || (platformId == 128);
        }

        private const String MonoRuntimeTypeName = @"Mono.Runtime";
        public static Boolean IsRunningMono { get; } 
        public static Boolean IsUnix { get; }
    }
}


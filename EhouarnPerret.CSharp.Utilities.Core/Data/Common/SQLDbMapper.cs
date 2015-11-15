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
using System.Data;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public interface IDbMapper : IDisposable
    {
    }

    public abstract class DbMappingNamedAttribute : Attribute
    {
        protected DbMappingNamedAttribute(String name)
        {
            this.Name = name;
        }

        public String Name { get; }
    }

    public class DbMapper : Disposable, IDbMapper
    {
        public DbMapper(IDbConnection connection)
        {
            this.Connection = ExceptionHelpers.ThrowIfNull(connection, nameof(connection));
        }

        private IDbConnection Connection { get; }
    }

    public class DbMapperColumnAttribute : DbMappingNamedAttribute
    {
        protected DbMapperColumnAttribute(String name)
            : base(name)
        {
            this.Name = name;
        }

        public String Name { get; }
    }

    public class DbMapperIndexAttribute : DbMappingNamedAttribute
    {
        protected DbMapperIndexAttribute(String name)
            : base(name)
        {
            this.Name = name;
        }

        public String Name { get; }
    }

    public class DbMapperTableAttribute : DbMappingNamedAttribute
    {
        protected DbMapperTableAttribute(String name)
            : base(name)
        {
            this.Name = name;
        }

        public String Name { get; }
    }

    public class DbMapperPrimaryKeyAttribute : DbMappingNamedAttribute
    {
        protected DbMapperPrimaryKeyAttribute(String name)
            : base(name)
        {
            this.Name = name;
        }

        public String Name { get; }
    }
}


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
    public interface IDbORM : IDisposable
    {
        public void CreateTable(String tableName)
        {
        }

        public void CreateView()
        {
        }
    }

    public abstract class DbORMNamedAttribute : Attribute
    {
        protected DbORMNamedAttribute(String name)
        {
            this.Name = name;
        }

        public String Name { get; }
    }

    public class ORM : Disposable, IDbORM
    {
        public ORM(IDbConnection connection)
        {
            this.Connection = ExceptionHelpers.ThrowIfNull(connection, nameof(connection));
        }

        private IDbConnection Connection { get; }
    }

    public class ORMColumnAttribute : DbORMNamedAttribute
    {
        protected ORMColumnAttribute(String name)
        {
            this.Name = name;
        }

        public String Name { get; }
    }

    public class ORMIndexAttribute : DbORMNamedAttribute
    {
        protected ORMIndexAttribute(String name)
        {
            this.Name = name;
        }

        public String Name { get; }
    }

    public class ORMTableAttribute : DbORMNamedAttribute
    {
        protected ORMTableAttribute(String name)
        {
            this.Name = name;
        }

        public String Name { get; }
    }

    public class ORMPrimaryKeyAttribute : DbORMNamedAttribute
    {
        protected ORMPrimaryKeyAttribute(String name)
        {
            this.Name = name;
        }

        public String Name { get; }
    }
}


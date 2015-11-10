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
using System.Collections.Generic;

namespace EhouarnPerret.CSharp.Utilities.Core
{
    public interface ITree<T> : IEnumerable<T>
    {
        ITreeNode<T> Root { get; }
        
        IEnumerable<ITreeNode<T>> Nodes { get; }
    }

    public interface ITreeNode<T> : IEnumerable<T>
    {
        T Value { get; set; }
    }

    public interface IBinaryTree<T> : ITree<T>
    {

    }
}


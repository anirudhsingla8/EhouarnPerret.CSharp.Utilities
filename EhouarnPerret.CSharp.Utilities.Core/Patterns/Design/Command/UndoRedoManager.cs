//
// UndoRedoManager.cs
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

namespace EhouarnPerret.CSharp.Utilities.Core.Patterns.Design.Command
{
    public class UndoRedoManager
    {
        public UndoRedoManager(UInt16 capacity = 32)
        {
            this.UndoCommands = new Stack<IReversibleCommand>();
            this.RedoCommands = new Stack<IReversibleCommand>();
        }

        public UInt16 LevelCapacity
        {
            get;
            set;
        }
        public UInt16 LevelCount
        {
            get
            {
                return Convert.ToUInt16(this.UndoCommands.Count + this.RedoCommands.Count);
            }
        }

        private Stack<IReversibleCommand> UndoCommands { get; }
        private Stack<IReversibleCommand> RedoCommands { get; }

        public void AddExecute(IReversibleCommand reversibleActionCommand)
        {
            this.UndoCommands.Push(reversibleActionCommand);

            // Too simple?
            this.RedoCommands.Clear();

            reversibleActionCommand.Execute();
        }
        public void AddExecute(Action executeAction, Action unexecuteAction)
        {
            var reversibleActionCommand = new ReversibleActionCommand(executeAction, unexecuteAction);

            this.AddExecute(reversibleActionCommand);
        }

        public void Undo(UInt16 levels = 1)
        {
            for (var i = 0; i < levels; i++)
            {
                var reversibleCommand = this.UndoCommands.Pop();
                reversibleCommand.Unexecute();
                this.RedoCommands.Push(reversibleCommand);
            }

        }
        public void Redo(UInt16 levels = 1)
        {
            for (var i = 0; i < levels; i++)
            {
                var reversibleCommand = this.RedoCommands.Pop();
                reversibleCommand.Execute();
                this.UndoCommands.Push(reversibleCommand);
            }
        }

        public void Clear()
        {
            this.UndoCommands.Clear();
            this.RedoCommands.Clear();
        }
    }
}


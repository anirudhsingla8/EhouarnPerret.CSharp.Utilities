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
using System.Collections.Generic;
using EhouarnPerret.CSharp.Utilities.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Dynamic;
using System.Configuration;
using System.Net;
using System.ComponentModel;

namespace EhouarnPerret.CSharp.Utilities.Harness
{
    public static class Program
    {
        public static void Main(params String[] arguments)
        {

            // Mono Databindings Support... WTF?
            var form = new Form();

            var content = new Content();

            var button = new Button() 
            { 
                Dock =  DockStyle.Top, 
            };

            button.Click += (sender, e) =>
            {
                content.String += "meuh";
                Console.WriteLine(content.String);
            };

            content.PropertyChanged += (sender, e) => Console.WriteLine("42");
            
            var binding = button.DataBindings.Add(@"Text", content, @"String", true, DataSourceUpdateMode.OnPropertyChanged, String.Empty);
                        
            binding.BindingComplete += (sender, e) => Console.WriteLine(@"BindingComplete");
            binding.Format += (sender, e) => Console.WriteLine(@"Format");
            binding.Parse += (sender, e) => Console.WriteLine(@"Parse");

            content.AnotherThing.String = @"d";

            form.Controls.Add(button);

            Application.Run(form);
        }
    }

    public static class BindingHelpers
    {

    }


    public class Content : INotifyPropertyChanged
    {
        AnotherThing _anotherThing = new AnotherThing();
        public AnotherThing AnotherThing
        {
            get
            {
                return _anotherThing;
            }
            set
            {
                _anotherThing = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(@"AnotherThing"));
            }
        }
        
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        String _string = @"Hello";
        public String String
        {
            get
            {
                return _string;
            }
            set
            {
                _string = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(@"String"));
            }
        } 
    }

    public class AnotherThing : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        String _string = @"Hello";
        public String String
        {
            get
            {
                return _string;
            }
            set
            {
                _string = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(@"String"));
            }
        } 
    }
}

//
// MatchExtensions.cs
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
using System.Text.RegularExpressions;

namespace EhouarnPerret.CSharp.Utilities.Core.Text.RegularExpressions
{
    public static class MatchExtensions
    {
        public static IReadOnlyDictionary<String, String> MatchNamedCaptures(this Regex regex, String input)
        {
            var namedCaptureDictionary = new Dictionary<String, String>();

            var groupCollection = regex.Match(input).Groups;

            var groupNames = regex.GetGroupNames();

            foreach (var groupName in groupNames)
            {
                if (groupCollection[groupName].Captures.Count > 0)
                {
                    namedCaptureDictionary.Add(groupName, groupCollection[groupName].Value);
                }
            }

            return namedCaptureDictionary;
        }
    }
}


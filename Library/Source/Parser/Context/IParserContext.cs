#region License
//=============================================================================
// Vici Core - Productivity Library for .NET 3.5 
//
// Copyright (c) 2008-2012 Philippe Leybaert
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
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//=============================================================================
#endregion

using System;

namespace Vici.Core.Parser
{
    [Flags]
    public enum AssignmentPermissions { None = 0, ExistingVariable = 1, NewVariable = 2, Variable = 3, Property = 4, Indexer = 8, All = 15 }

    public interface IParserContext
    {
        bool Get(string varName, out object value, out Type type);
        bool Exists(string varName);

        bool ToBoolean(object value);

        IParserContext CreateLocal();

        void SetLocal(string varName, object value, Type type);
        void SetLocal<T>(string varName, T value);

        void Set(string varName, object value, Type type);
        void Set<T>(string varName, T value);

		AssignmentPermissions AssignmentPermissions { get; set; }

        StringComparison StringComparison { get; }

        string Format(string formatString, params object[] parameters);
    }
}
// Copyright (c) 2012 DotNetAnywhere
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

#if !LOCALTEST

using System.Runtime.CompilerServices;
using System.Reflection;

namespace System {
	public abstract class Type : MemberInfo {

		public static readonly Type[] EmptyTypes = new Type[0];

		[MethodImpl(MethodImplOptions.InternalCall)]
		extern public static Type GetTypeFromHandle(RuntimeTypeHandle handle);

		public abstract Type BaseType {
			get;
		}

		public abstract bool IsEnum {
			get;
		}

		public abstract string Namespace {
			get;
		}

		public abstract string FullName {
			get;
		}

		public abstract bool IsGenericType {
			get;
		}

		public abstract Type GetGenericTypeDefinition();

		public abstract Type[] GetGenericArguments();

		extern public bool IsValueType {
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		//
		// Summary:
		//     Searches for the public method with the specified name.
		//
		// Parameters:
		//   name:
		//     The string containing the name of the public method to get.
		//
		// Returns:
		//     An object that represents the public method with the specified name, if found;
		//     otherwise, null.
		//
		// Exceptions:
		//   T:System.Reflection.AmbiguousMatchException:
		//     More than one method is found with the specified name.
		//
		//   T:System.ArgumentNullException:
		//     name is null.
		[MethodImpl(MethodImplOptions.InternalCall)]
		extern public MethodInfo GetMethod(string name);


		public override string ToString() {
			return this.FullName;
		}
	}
}

#endif

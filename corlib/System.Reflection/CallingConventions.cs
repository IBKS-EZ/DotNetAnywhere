﻿using System.Runtime.InteropServices;

namespace System.Reflection
{
    //
    // Summary:
    //     Defines the valid calling conventions for a method.
    public enum CallingConventions
    {
        //
        // Summary:
        //     Specifies the default calling convention as determined by the common language
        //     runtime. Use this calling convention for static methods. For instance or virtual
        //     methods use HasThis.
        Standard = 1,
        //
        // Summary:
        //     Specifies the calling convention for methods with variable arguments.
        VarArgs = 2,
        //
        // Summary:
        //     Specifies that either the Standard or the VarArgs calling convention may be used.
        Any = 3,
        //
        // Summary:
        //     Specifies an instance or virtual method (not a static method). At run-time, the
        //     called method is passed a pointer to the target object as its first argument
        //     (the this pointer). The signature stored in metadata does not include the type
        //     of this first argument, because the method is known and its owner class can be
        //     discovered from metadata.
        HasThis = 32,
        //
        // Summary:
        //     Specifies that the signature is a function-pointer signature, representing a
        //     call to an instance or virtual method (not a static method). If ExplicitThis
        //     is set, HasThis must also be set. The first argument passed to the called method
        //     is still a this pointer, but the type of the first argument is now unknown. Therefore,
        //     a token that describes the type (or class) of the this pointer is explicitly
        //     stored into its metadata signature.
        ExplicitThis = 64
    }
}
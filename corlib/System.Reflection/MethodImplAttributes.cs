using System.Runtime.InteropServices;

namespace System.Reflection
{
    //
    // Summary:
    //     Specifies flags for the attributes of a method implementation.
    public enum MethodImplAttributes
    {
        //
        // Summary:
        //     Specifies that the method implementation is in Microsoft intermediate language
        //     (MSIL).
        IL = 0,
        //
        // Summary:
        //     Specifies that the method is implemented in managed code.
        Managed = 0,
        //
        // Summary:
        //     Specifies that the method implementation is native.
        Native = 1,
        //
        // Summary:
        //     Specifies that the method implementation is in Optimized Intermediate Language
        //     (OPTIL).
        OPTIL = 2,
        //
        // Summary:
        //     Specifies flags about code type.
        CodeTypeMask = 3,
        //
        // Summary:
        //     Specifies that the method implementation is provided by the runtime.
        Runtime = 3,
        //
        // Summary:
        //     Specifies whether the method is implemented in managed or unmanaged code.
        ManagedMask = 4,
        //
        // Summary:
        //     Specifies that the method is implemented in unmanaged code.
        Unmanaged = 4,
        //
        // Summary:
        //     Specifies that the method cannot be inlined.
        NoInlining = 8,
        //
        // Summary:
        //     Specifies that the method is not defined.
        ForwardRef = 16,
        //
        // Summary:
        //     Specifies that the method is single-threaded through the body. Static methods
        //     (Shared in Visual Basic) lock on the type, whereas instance methods lock on the
        //     instance. You can also use the C# lock statement or the Visual Basic SyncLock
        //     statement for this purpose.
        Synchronized = 32,
        //
        // Summary:
        //     Specifies that the method is not optimized by the just-in-time (JIT) compiler
        //     or by native code generation (see Ngen.exe) when debugging possible code generation
        //     problems.
        NoOptimization = 64,
        //
        // Summary:
        //     Specifies that the method signature is exported exactly as declared.
        PreserveSig = 128,
        //
        // Summary:
        //     Specifies that the method should be inlined wherever possible.
        AggressiveInlining = 256,
        //
        // Summary:
        //     Specifies an internal call.
        InternalCall = 4096,
        //
        // Summary:
        //     Specifies a range check value.
        MaxMethodImplVal = 65535
    }
}
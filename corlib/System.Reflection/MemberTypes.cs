using System.Runtime.InteropServices;

namespace System.Reflection
{
    //
    // Summary:
    //     Marks each type of member that is defined as a derived class of System.Reflection.MemberInfo.
    
    public enum MemberTypes
    {
        //
        // Summary:
        //     Specifies that the member is a constructor
        Constructor = 1,
        //
        // Summary:
        //     Specifies that the member is an event.
        Event = 2,
        //
        // Summary:
        //     Specifies that the member is a field.
        Field = 4,
        //
        // Summary:
        //     Specifies that the member is a method.
        Method = 8,
        //
        // Summary:
        //     Specifies that the member is a property.
        Property = 16,
        //
        // Summary:
        //     Specifies that the member is a type.
        TypeInfo = 32,
        //
        // Summary:
        //     Specifies that the member is a custom member type.
        Custom = 64,
        //
        // Summary:
        //     Specifies that the member is a nested type.
        NestedType = 128,
        //
        // Summary:
        //     Specifies all member types.
        All = 191
    }
}

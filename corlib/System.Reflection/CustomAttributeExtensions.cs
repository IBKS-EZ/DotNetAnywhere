using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace System.Reflection
{
    public static class CustomAttributeExtensions
    {
        //
        // Summary:
        //     Retrieves a collection of custom attributes that are applied to a specified member.
        //
        // Parameters:
        //   element:
        //     The member to inspect.
        //
        // Returns:
        //     A collection of the custom attributes that are applied to element, or an empty
        //     collection if no such attributes exist.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     element is null.
        //
        //   T:System.NotSupportedException:
        //     element is not a constructor, method, property, event, type, or field.
        //
        //   T:System.TypeLoadException:
        //     A custom attribute type cannot be loaded.
        [MethodImpl(MethodImplOptions.InternalCall)]
        //extern public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element);
        extern public static IEnumerable<Attribute> GetCustomAttributes(MemberInfo element);

    }
}

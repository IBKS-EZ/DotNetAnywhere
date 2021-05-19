using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
    //
    // Summary:
    //     Exposes the public members of the System.Reflection.MethodInfo class to unmanaged
    //     code.
    public interface _MethodInfo
    {
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MemberInfo.DeclaringType
        //     property.
        //
        // Returns:
        //     The Type object for the class that declares this member.
        Type DeclaringType { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.Attributes
        //     property.
        //
        // Returns:
        //     One of the System.Reflection.MethodAttributes values.
        MethodAttributes Attributes { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.CallingConvention
        //     property.
        //
        // Returns:
        //     One of the System.Reflection.CallingConventions values.
        CallingConventions CallingConvention { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsPublic
        //     property.
        //
        // Returns:
        //     true if this method is public; otherwise, false.
        bool IsPublic { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsPrivate
        //     property.
        //
        // Returns:
        //     true if access to this method is restricted to other members of the class itself;
        //     otherwise, false.
        bool IsPrivate { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsFamily
        //     property.
        //
        // Returns:
        //     true if access to the class is restricted to members of the class itself and
        //     to members of its derived classes; otherwise, false.
        bool IsFamily { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsAssembly
        //     property.
        //
        // Returns:
        //     true if this method can be called by other classes in the same assembly; otherwise,
        //     false.
        bool IsAssembly { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsFamilyAndAssembly
        //     property.
        //
        // Returns:
        //     true if access to this method is restricted to members of the class itself and
        //     to members of derived classes that are in the same assembly; otherwise, false.
        bool IsFamilyAndAssembly { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsFamilyOrAssembly
        //     property.
        //
        // Returns:
        //     true if access to this method is restricted to members of the class itself, members
        //     of derived classes wherever they are, and members of other classes in the same
        //     assembly; otherwise, false.
        bool IsFamilyOrAssembly { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsStatic
        //     property.
        //
        // Returns:
        //     true if this method is static; otherwise, false.
        bool IsStatic { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsFinal
        //     property.
        //
        // Returns:
        //     true if this method is final; otherwise, false.
        bool IsFinal { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsVirtual
        //     property.
        //
        // Returns:
        //     true if this method is virtual; otherwise, false.
        bool IsVirtual { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsHideBySig
        //     property.
        //
        // Returns:
        //     true if the member is hidden by signature; otherwise, false.
        bool IsHideBySig { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsAbstract
        //     property.
        //
        // Returns:
        //     true if the method is abstract; otherwise, false.
        bool IsAbstract { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsSpecialName
        //     property.
        //
        // Returns:
        //     true if this method has a special name; otherwise, false.
        bool IsSpecialName { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.IsConstructor
        //     property.
        //
        // Returns:
        //     true if this method is a constructor; otherwise, false.
        bool IsConstructor { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.MethodHandle
        //     property.
        //
        // Returns:
        //     A System.RuntimeMethodHandle object.
        RuntimeMethodHandle MethodHandle { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MemberInfo.ReflectedType
        //     property.
        //
        // Returns:
        //     The Type object that was used to obtain this MemberInfo object.
        Type ReflectedType { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodInfo.ReturnTypeCustomAttributes
        //     property.
        //
        // Returns:
        //     An System.Reflection.ICustomAttributeProvider object representing the custom
        //     attributes for the return type.
        ICustomAttributeProvider ReturnTypeCustomAttributes { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MemberInfo.Name
        //     property.
        //
        // Returns:
        //     A System.String object containing the name of this member.
        string Name { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MemberInfo.MemberType
        //     property.
        //
        // Returns:
        //     One of the System.Reflection.MemberTypes values indicating the type of member.
        MemberTypes MemberType { get; }
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodInfo.ReturnType
        //     property.
        //
        // Returns:
        //     The return type of this method.
        Type ReturnType { get; }

        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Object.Equals(System.Object)
        //     method.
        //
        // Parameters:
        //   other:
        //     The System.Object to compare with the current System.Object.
        //
        // Returns:
        //     true if the specified System.Object is equal to the current System.Object; otherwise,
        //     false.
        bool Equals(object other);
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodInfo.GetBaseDefinition
        //     method.
        //
        // Returns:
        //     A System.Reflection.MethodInfo object for the first implementation of this method.
        MethodInfo GetBaseDefinition();
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MemberInfo.GetCustomAttributes(System.Boolean)
        //     method.
        //
        // Parameters:
        //   inherit:
        //     true to search this member's inheritance chain to find the attributes; otherwise,
        //     false.
        //
        // Returns:
        //     An array that contains all the custom attributes, or an array with zero (0) elements
        //     if no attributes are defined.
        object[] GetCustomAttributes(bool inherit);
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MemberInfo.GetCustomAttributes(System.Type,System.Boolean)
        //     method.
        //
        // Parameters:
        //   attributeType:
        //     The type of attribute to search for. Only attributes that are assignable to this
        //     type are returned.
        //
        //   inherit:
        //     true to search this member's inheritance chain to find the attributes; otherwise,
        //     false.
        //
        // Returns:
        //     An array of custom attributes applied to this member, or an array with zero (0)
        //     elements if no attributes have been applied.
        object[] GetCustomAttributes(Type attributeType, bool inherit);
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Object.GetHashCode
        //     method.
        //
        // Returns:
        //     The hash code for the current instance.
        int GetHashCode();
        //
        // Summary:
        //     Maps a set of names to a corresponding set of dispatch identifiers.
        //
        // Parameters:
        //   riid:
        //     Reserved for future use. Must be IID_NULL.
        //
        //   rgszNames:
        //     An array of names to be mapped.
        //
        //   cNames:
        //     The count of the names to be mapped.
        //
        //   lcid:
        //     The locale context in which to interpret the names.
        //
        //   rgDispId:
        //     An array allocated by the caller that receives the identifiers corresponding
        //     to the names.
        //void GetIDsOfNames(ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.GetMethodImplementationFlags
        //     method.
        //
        // Returns:
        //     One of the System.Reflection.MethodImplAttributes values.
        MethodImplAttributes GetMethodImplementationFlags();
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.GetParameters
        //     method.
        //
        // Returns:
        //     An array of type System.Reflection.ParameterInfo containing information that
        //     matches the signature of the method (or constructor) reflected by this instance.
        //ParameterInfo[] GetParameters();
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Type.GetType
        //     method.
        //
        // Returns:
        //     A System.Type object.
        Type GetType();
        //
        // Summary:
        //     Retrieves the type information for an object, which can be used to get the type
        //     information for an interface.
        //
        // Parameters:
        //   iTInfo:
        //     The type information to return.
        //
        //   lcid:
        //     The locale identifier for the type information.
        //
        //   ppTInfo:
        //     A pointer to the requested type information object.
        void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);
        //
        // Summary:
        //     Retrieves the number of type information interfaces that an object provides (either
        //     0 or 1).
        //
        // Parameters:
        //   pcTInfo:
        //     When this method returns, contains a pointer to a location that receives the
        //     number of type information interfaces provided by the object. This parameter
        //     is passed uninitialized.
        void GetTypeInfoCount(out uint pcTInfo);
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.Invoke(System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)
        //     method.
        //
        // Parameters:
        //   obj:
        //     The instance that created this method.
        //
        //   invokeAttr:
        //     One of the BindingFlags values that specifies the type of binding.
        //
        //   binder:
        //     A Binder that defines a set of properties and enables the binding, coercion of
        //     argument types, and invocation of members using reflection. If binder is null,
        //     then Binder.DefaultBinding is used.
        //
        //   parameters:
        //     An array of type Object used to match the number, order, and type of the parameters
        //     for this constructor, under the constraints of binder. If this constructor does
        //     not require parameters, pass an array with zero elements, as in Object[] parameters
        //     = new Object[0]. Any object in this array that is not explicitly initialized
        //     with a value will contain the default value for that object type. For reference
        //     type elements, this value is null. For value type elements, this value is 0,
        //     0.0, or false, depending on the specific element type.
        //
        //   culture:
        //     A System.Globalization.CultureInfo object used to govern the coercion of types.
        //     If this is null, the System.Globalization.CultureInfo for the current thread
        //     is used.
        //
        // Returns:
        //     An instance of the class associated with the constructor.
        //object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MethodBase.Invoke(System.Object,System.Object[])
        //     method.
        //
        // Parameters:
        //   obj:
        //     The instance that created this method.
        //
        //   parameters:
        //     An argument list for the invoked method or constructor. This is an array of objects
        //     with the same number, order, and type as the parameters of the method or constructor
        //     to be invoked. If there are no parameters, parameters should be null.If the method
        //     or constructor represented by this instance takes a ref parameter (ByRef in Visual
        //     Basic), no special attribute is required for that parameter to invoke the method
        //     or constructor using this function. Any object in this array that is not explicitly
        //     initialized with a value will contain the default value for that object type.
        //     For reference type elements, this value is null. For value type elements, this
        //     value is 0, 0.0, or false, depending on the specific element type.
        //
        // Returns:
        //     An instance of the class associated with the constructor.
        object Invoke(object obj, object[] parameters);
        //
        // Summary:
        //     Provides access to properties and methods exposed by an object.
        //
        // Parameters:
        //   dispIdMember:
        //     An identifier for the member.
        //
        //   riid:
        //     Reserved for future use. Must be IID_NULL.
        //
        //   lcid:
        //     The locale context in which to interpret arguments.
        //
        //   wFlags:
        //     Flags describing the context of the call.
        //
        //   pDispParams:
        //     A pointer to a structure containing an array of arguments, an array of argument
        //     DISPIDs for named arguments, and counts for the number of elements in the arrays.
        //
        //   pVarResult:
        //     A pointer to the location where the result will be stored.
        //
        //   pExcepInfo:
        //     A pointer to a structure that contains exception information.
        //
        //   puArgErr:
        //     The index of the first argument that has an error.
        //void Invoke(uint dispIdMember, ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Reflection.MemberInfo.IsDefined(System.Type,System.Boolean)
        //     method.
        //
        // Parameters:
        //   attributeType:
        //     The Type object to which the custom attributes are applied.
        //
        //   inherit:
        //     true to search this member's inheritance chain to find the attributes; otherwise,
        //     false.
        //
        // Returns:
        //     true if one or more instance of the attributeType parameter is applied to this
        //     member; otherwise, false.
        bool IsDefined(Type attributeType, bool inherit);
        //
        // Summary:
        //     Provides COM objects with version-independent access to the System.Object.ToString
        //     method.
        //
        // Returns:
        //     A string that represents the current System.Object.
        string ToString();
    }
}

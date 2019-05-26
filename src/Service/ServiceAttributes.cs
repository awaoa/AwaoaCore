using System;

namespace Awaoa.Core.Service
{
    /// <summary>
    /// Indicates that the type and any derived types that this attribute is applied to
    /// are considered a scoped service by the default awaoa service discovery mechanism
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ScopedServiceAttribute : Attribute
    {
    }

    /// <summary>
    /// Indicates that the type and any derived types that this attribute is applied to
    /// are considered a transient service by the default awaoa service discovery mechanism
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class TransientServiceAttribute : Attribute
    {
    }

    /// <summary>
    /// Indicates that the type and any derived types that this attribute is applied to
    /// are considered a singleton service by the default awaoa service discovery mechanism
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class SingletonServiceAttribute : Attribute
    {
    }
}

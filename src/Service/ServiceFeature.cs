using System.Collections.Generic;
using System.Reflection;

namespace Awaoa.Core.Service
{
    /// <summary>
    /// The list of services types in an MVC application. The <see cref="ServiceFeature"/> can be populated
    /// using the <see cref="ApplicationPartManager"/> that is available during startup at <see cref="IMvcBuilder.PartManager"/>
    /// and <see cref="IMvcCoreBuilder.PartManager"/> or at a later stage by requiring the <see cref="ApplicationPartManager"/>
    /// as a dependency in a component.
    /// </summary>
    public class ServiceFeature
    {
        /// <summary>
        /// Gets the list of scoped services types in an MVC application.
        /// </summary>
        public IList<TypeInfo> ScopedServices { get; } = new List<TypeInfo>();

        /// <summary>
        /// Gets the list of transient services types in an MVC application.
        /// </summary>
        public IList<TypeInfo> TransientServices { get; } = new List<TypeInfo>();

        /// <summary>
        /// Gets the list of singleton services types in an MVC application.
        /// </summary>
        public IList<TypeInfo> SingletonServices { get; } = new List<TypeInfo>();
    }
}

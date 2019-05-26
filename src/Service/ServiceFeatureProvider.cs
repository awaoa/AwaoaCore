using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Awaoa.Core.Service
{
    /// <summary>
    /// Discovers controllers from a list of <see cref="ApplicationPart"/> instances.
    /// </summary>
    public class ServiceFeatureProvider : IApplicationFeatureProvider<ServiceFeature>
    {
        private const string ServiceTypeNameSuffix = "Service";

        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ServiceFeature feature)
        {
            foreach (var part in parts.OfType<IApplicationPartTypeProvider>())
            {
                foreach (var type in part.Types)
                {
                    if (IsScopedService(type) && !feature.ScopedServices.Contains(type))
                    {
                        feature.ScopedServices.Add(type);
                    }

                    if (IsSingletonService(type) && !feature.SingletonServices.Contains(type))
                    {
                        feature.SingletonServices.Add(type);
                    }

                    if (IsTransientService(type) && !feature.TransientServices.Contains(type))
                    {
                        feature.TransientServices.Add(type);
                    }
                }
            }
        }

        /// <summary>
        /// Determines if a given <paramref name="typeInfo"/> is a scoped service.
        /// </summary>
        /// <param name="typeInfo">The <see cref="TypeInfo"/> candidate.</param>
        /// <returns><code>true</code> if the type is a scoped service; otherwise <code>false</code>.</returns>
        protected virtual bool IsScopedService(TypeInfo typeInfo)
        {
            return IsService(typeInfo, typeof(ScopedServiceAttribute));
        }

        /// <summary>
        /// Determines if a given <paramref name="typeInfo"/> is a transient service.
        /// </summary>
        /// <param name="typeInfo">The <see cref="TypeInfo"/> candidate.</param>
        /// <returns><code>true</code> if the type is a transient service; otherwise <code>false</code>.</returns>
        protected virtual bool IsTransientService(TypeInfo typeInfo)
        {
            return IsService(typeInfo, typeof(TransientServiceAttribute));
        }

        /// <summary>
        /// Determines if a given <paramref name="typeInfo"/> is a singleton service.
        /// </summary>
        /// <param name="typeInfo">The <see cref="TypeInfo"/> candidate.</param>
        /// <returns><code>true</code> if the type is a singleton service; otherwise <code>false</code>.</returns>
        protected virtual bool IsSingletonService(TypeInfo typeInfo)
        {
            return IsService(typeInfo, typeof(SingletonServiceAttribute));
        }

        private bool IsService(TypeInfo typeInfo, Type targetServiceType)
        {
            if (!typeInfo.IsClass)
            {
                return false;
            }

            if (typeInfo.IsAbstract)
            {
                return false;
            }

            // We only consider public top-level classes as service. IsPublic returns false for nested
            // classes, regardless of visibility modifiers
            if (!typeInfo.IsPublic)
            {
                return false;
            }

            if (typeInfo.ContainsGenericParameters)
            {
                return false;
            }

            if (!typeInfo.Name.EndsWith(ServiceTypeNameSuffix, StringComparison.OrdinalIgnoreCase) &&
                !typeInfo.IsDefined(targetServiceType))
            {
                return false;
            }
            return true;
        }
    }
}

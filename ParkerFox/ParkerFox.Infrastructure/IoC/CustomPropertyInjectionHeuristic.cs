using Ninject;
using Ninject.Components;
using Ninject.Selection.Heuristics;
using System;
using System.Linq;
using System.Reflection;

namespace ParkerFox.Infrastructure.IoC
{
    public class CustomPropertyInjectionHeuristic : NinjectComponent, IInjectionHeuristic
    {
        private readonly IKernel kernel;

        private static readonly string[] knownAssemblies = new[] { "ParkerFox.Infrastructure" };

        public CustomPropertyInjectionHeuristic(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public bool ShouldInject(MemberInfo memberInfo)
        {
            var propertyInfo = memberInfo as PropertyInfo;
            return ShouldInject(propertyInfo);
        }

        private bool ShouldInject(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                return false;

            if (!propertyInfo.CanWrite)
                return false;

            Type propertyType = propertyInfo.PropertyType;
            string assemblyName = propertyType.Assembly.GetName().Name;
            if (!knownAssemblies.Contains(assemblyName))
                return false;

            var instance = kernel.TryGet(propertyType);
            return instance != null;
        }
    }
}

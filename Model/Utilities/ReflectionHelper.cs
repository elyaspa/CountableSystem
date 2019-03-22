using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CS.Model.Utilities
{
    public sealed class ReflectionHelper
    {
        public IEnumerable<Type> GetDescendantBase(Type Tipo)
        {
            return Tipo.Assembly.GetTypes().Where(t => t.BaseType == (Tipo));
        }
        public IEnumerable<Type> GetDescendantAssignable(Assembly assembly, Type baseType)
        {
            return assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t));
        }
    }
}

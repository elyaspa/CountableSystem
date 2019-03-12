using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CountableSystem.Module.BusinessObjects.Utilities
{
    public sealed class AyudanteDeReflection
    {
        public IEnumerable<Type> ObtenerDescendientesBase(Type Tipo)
        {
            return Tipo.Assembly.GetTypes().Where(t => t.BaseType == (Tipo));
        }
        public IEnumerable<Type> ObtenerDescendientesAsignables(Assembly assembly, Type baseType)
        {
            return assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t));
        }
    }
}

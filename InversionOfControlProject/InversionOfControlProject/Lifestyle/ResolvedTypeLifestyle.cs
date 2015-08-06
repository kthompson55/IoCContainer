using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlProject.Lifestyle
{
    public class ResolvedTypeLifestyle
    {
        public Type ResolvedType { get; set; }
        public LifestyleType Lifestyle { get; set; }
        public object Instance { get; set; }

        public ResolvedTypeLifestyle(Type resolvedType)
        {
            ResolvedType = resolvedType;
            Lifestyle = LifestyleType.Transient;
            Instance = null;
        }

        public ResolvedTypeLifestyle(Type resolvedType, LifestyleType lifetime)
        {
            ResolvedType = resolvedType;
            Lifestyle = lifetime;
        }
    }
}

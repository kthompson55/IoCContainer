using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using InversionOfControlProject.Containers.Interface;
using InversionOfControlProject.Lifestyle;
using InversionOfControlProject.Containers.Exceptions;

namespace InversionOfControlProject.Containers
{
    public class Container : IContainer
    {
        Dictionary<Type, ResolvedTypeLifestyle> registerMap;

        public Container()
        {
            registerMap = new Dictionary<Type, ResolvedTypeLifestyle>();
        }

        // Registers type with object
        public void Register<I,T>()
        {
            if(registerMap.ContainsKey(typeof(I)))
            {
                throw new TypeAlreadyRegisteredException(typeof(I));
            }
            Register<I, T>(LifestyleType.Transient);
        }

        public void Register<I,T>(LifestyleType lifetime)
        {
            if (registerMap.ContainsKey(typeof(I)))
            {
                throw new TypeAlreadyRegisteredException(typeof(I));
            }
            ResolvedTypeLifestyle resolvedType = new ResolvedTypeLifestyle(typeof(T), lifetime);
            registerMap.Add(typeof(I), resolvedType);
        }

        // Resolves provided Type
        public I Resolve<I>()
        {
            if (!registerMap.ContainsKey(typeof(I)))
            {
                throw new TypeNotRegisteredException(typeof(I));
            }
            return (I)RecursiveResolve(typeof(I));
        }

        // Resolves provided type
        private object RecursiveResolve(Type toBeResolved)
        {
            ResolvedTypeLifestyle resolvedType = null;
            try
            {
                resolvedType = registerMap[toBeResolved];
            }
            catch
            {
                resolvedType = new ResolvedTypeLifestyle(toBeResolved);
                resolvedType.Lifestyle = LifestyleType.Static;
                foreach(Type curType in registerMap.Keys)
                {
                    if(registerMap[curType].Equals(resolvedType))
                    {
                        resolvedType.Instance = registerMap[curType].Instance;
                        break;
                    }
                }
            }

            // Check if container-static object already has an instance
            if(resolvedType.Lifestyle == LifestyleType.Static && resolvedType.Instance != null)
            {
                foreach(ResolvedTypeLifestyle currentType in registerMap.Values)
                {
                    if (currentType.Equals(resolvedType))
                    {
                        return resolvedType.Instance;
                    }
                }
            }

            // Find out what parameters needed for the object
            ConstructorInfo typeConstructor = resolvedType.ResolvedType.GetConstructors().First<ConstructorInfo>();
            List<ParameterInfo> typeParameters = typeConstructor.GetParameters().ToList();
            List<object> resolvedParameters = new List<object>();

            // Iterate through parameters
            foreach (ParameterInfo parameter in typeParameters)
            {
                Type parType = parameter.ParameterType;
                object resolvedParameter = RecursiveResolve(parType);
                resolvedParameters.Add(resolvedParameter);
            }

            object resolvedObject = typeConstructor.Invoke(resolvedParameters.ToArray());
            resolvedType.Instance = resolvedObject;
            return resolvedObject;
        }
    }
}

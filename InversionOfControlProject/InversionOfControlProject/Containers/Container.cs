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
        Dictionary<Type, Type> registerMap;

        public Container()
        {
            registerMap = new Dictionary<Type, Type>();
        }

        // Registers type with object
        public void Register<I,T>()
        {
            if(registerMap.ContainsKey(typeof(I)))
            {
                throw new TypeAlreadyRegisteredException(typeof(I));
            }
            registerMap.Add(typeof(I), typeof(T));
        }

        // Resolves provided Type
        public I Resolve<I>()
        {
            if (!registerMap.ContainsKey(typeof(I)))
            {
                throw new TypeNotRegisteredException(typeof(I));
            }
            return (I)RecursiveResolve(registerMap[typeof(I)]);
        }

        // Resolves provided type
        private object RecursiveResolve(Type toBeResolved)
        {
            // Find out what parameters needed for the object
            ConstructorInfo typeConstructor = toBeResolved.GetConstructors().First<ConstructorInfo>();
            List<ParameterInfo> typeParameters = typeConstructor.GetParameters().ToList();
            List<object> resolvedParameters = new List<object>();

            // Iterate through parameters
            foreach (ParameterInfo parameter in typeParameters)
            {
                Type parType = parameter.ParameterType;
                object resolvedParameter = RecursiveResolve(parType);
                resolvedParameters.Add(resolvedParameter);
            }

            return typeConstructor.Invoke(resolvedParameters.ToArray());
        }
    }
}

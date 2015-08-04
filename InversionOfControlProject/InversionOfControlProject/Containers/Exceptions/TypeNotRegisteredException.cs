using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlProject.Containers.Exceptions
{
    public class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException(Type type) :
            base(String.Format("The type {0} is not registered to the container!", type.ToString())) { }
    }
}

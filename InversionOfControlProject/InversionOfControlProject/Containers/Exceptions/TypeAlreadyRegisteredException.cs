using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlProject.Containers.Exceptions
{
    public class TypeAlreadyRegisteredException : Exception
    {
        public TypeAlreadyRegisteredException(Type type) : 
            base(String.Format("The type {0} has already been registered!", type.ToString())) { }
    }
}

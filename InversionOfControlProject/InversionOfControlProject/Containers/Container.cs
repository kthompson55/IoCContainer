using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InversionOfControlProject.Containers.Interface;
using InversionOfControlProject.Lifestyle;

namespace InversionOfControlProject.Containers
{
    public class Container : IContainer
    {
        // Registers type with object
        public void Register<I,T>()
        {
            
        }

        // Resolves provided type
        public void Resolve<I>()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InversionOfControlProject.Containers.Interface;
using InversionOfControlProject.Lifestyle;

namespace InversionOfControlProject.Containers
{
    class Container : IContainer
    {
        private Dictionary<object, List<object>> register;

        public void Register(LifestyleTypeEnum lifestyle, object injected, params object[] injector)
        {
            
        }

        public void Resolve(params object[] injectors)
        {

        }
    }
}

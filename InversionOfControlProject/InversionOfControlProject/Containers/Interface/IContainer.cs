using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InversionOfControlProject.Lifestyle;

namespace InversionOfControlProject.Containers.Interface
{
    public interface IContainer
    {
        void Register<I,T>();
        void Resolve<I>();
    }
}

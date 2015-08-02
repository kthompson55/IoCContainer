using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InversionOfControlProject.Lifestyle;

namespace InversionOfControlProject
{
    public interface IContainer
    {
        void Register(object resolver, object resolvee, LifestyleType lifeStyle);
        void Resolve(object resolver);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlProject.Lifestyle
{
    public enum LifestyleTypeEnum
    {
        Transient,
        Singleton
    };
    public class LifestyleType
    {
        public LifestyleTypeEnum Type { get; set; }
    }
}

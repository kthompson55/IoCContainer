﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlProject.Lifestyle
{
    public enum LifestyleType
    {
        Transient, // new up every resolve
        Static // only ever have one in the container
    }
}

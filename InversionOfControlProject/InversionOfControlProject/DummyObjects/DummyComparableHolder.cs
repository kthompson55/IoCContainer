using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlProject.DummyObjects
{
    public class DummyComparableHolder
    {
        public DummyComparable Dummy { set; get; }

        public DummyComparableHolder(DummyComparable comparable)
        {
            Dummy = comparable;
        }
    }
}

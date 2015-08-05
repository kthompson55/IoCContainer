using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyObjects
{
    public class DummyComparable : IComparable
    {
        private static int counter = 0;
        private int _id;

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public DummyComparable()
        {
            _id = counter++;
        }

        public int CompareTo(Object o)
        {
            DummyComparable other = o as DummyComparable;
            if(other != null)
            {
                return ID.CompareTo(other.ID);
            }
            return -1;
        }
    }
}

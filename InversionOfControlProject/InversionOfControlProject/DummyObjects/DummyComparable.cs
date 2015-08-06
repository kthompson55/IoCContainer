using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InversionOfControlProject.Lifestyle;

namespace InversionOfControlProject.DummyObjects
{
    public class DummyComparable : IComparable, ILifestyle
    {
        private static int counter = 0;
        private int _id;
        private DateTime createdOn;

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
            createdOn = DateTime.Now;
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

        public DateTime GetCreatedOn()
        {
            return createdOn;
        }
    }
}

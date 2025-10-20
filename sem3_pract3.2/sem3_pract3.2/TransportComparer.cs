using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem3_pract3._2
{
    public class TransportComparer : IComparer<Transport>
    {
        public int Compare(Transport t1, Transport t2)
        {
            if (t1 is null || t2 is null) throw new ArgumentException("Некорректное значение параметра");
            return t1.CompareTo(t2);
        }
    }
}
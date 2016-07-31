using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSamples
{
    public static class IEnumerableExtensions
    {
        public static int MyCount<T>(this IEnumerable<T> sequence)
        {
            return sequence.Count();
        }
    }
}

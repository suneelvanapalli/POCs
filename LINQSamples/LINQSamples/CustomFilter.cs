using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSamples
{
   public static class CustomFilter
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T,bool> predicate)

        {
          //  var list = new List<T>();
            foreach(var item in source)
            {
                if (predicate(item))
                {
                    // list.Add(item);
                    yield return item;
                }
            }

           // return list;
        }
    }
}

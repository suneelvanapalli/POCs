using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSamples
{
    public class Adviser
    {
        public string AdviserID { get; set; }
        public string FirstName { get; set; }

        string _lastName;
        public string LastName
        {
            get
            {
                Console.WriteLine("returned {_lastname}");
                return _lastName;
            }
            set { _lastName = value; }
        }

    }
}

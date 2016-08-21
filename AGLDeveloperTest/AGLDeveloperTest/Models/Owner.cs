using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGLDeveloperTest.Models
{
    public class Owner
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }

        public List<Pet> pets = new List<Pet>();
    }
}
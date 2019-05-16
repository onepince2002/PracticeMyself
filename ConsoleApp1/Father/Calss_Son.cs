using System;
using System.Collections.Generic;
using System.Text;

namespace Google_API
{
    class Calss_Son : Calss_Father<Calss_Son.detil>
    {
        public class detil: Calss_Father_New
        {
            public string name { get; set; }

            public int age { get; set; }

            public string sex { get; set; }
        }
    }
}

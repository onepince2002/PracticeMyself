using System;
using System.Collections.Generic;
using System.Text;

namespace Google_API
{
    class Calss_Daughter: Calss_Father<Calss_Daughter.detil>
    {
        public class detil: Calss_Father_New
        {
            public string name { get; set; }

            public int weghit { get; set; }

            public string school { get; set; }

            public string sex { get; set; }
        }
    }
}

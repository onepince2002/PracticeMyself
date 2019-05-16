using System;
using System.Collections.Generic;
using System.Text;

namespace Google_API
{
    class Calss_Father
    {


    }


    //public abstract class Calss_Father<T>  也可使用
    //https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
    public abstract class  Calss_Father<T>  where T : Calss_Father_New, new()
    {
        public T data { get; set; }

        public string car { get; set; }

        public int phone { get; set; }
    }
}

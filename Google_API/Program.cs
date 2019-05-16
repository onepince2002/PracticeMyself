using System;
using Newtonsoft.Json;


namespace Google_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("輸入圖片網址");
            //string read = Console.ReadLine();
            Google_Vision go = new Google_Vision();
            go.post();

        }
    }
    
}

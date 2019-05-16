using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google_API;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = "{'data': {'name': 'Tom','age': 10,'sex': 'male'},'car': 'toyota','phone': 912345678}";
            string json2 = "{'data': {'name': 'Alice','age': 15,'weghit': 20,'school': 'ABC','sex':'female'},'car': 'toyota','phone': 912345678}";

            var jsonConver = JsonConvert.DeserializeObject<Calss_Son>(json);


            var jsonConver2 = JsonConvert.DeserializeObject<Calss_Daughter>(json2);

            var json3 = new Calss_Son.detil()
            {
                name = "eli",
                age = 5,
                sex = "male",
            };
            var json33 = new Calss_Son()
            {
                data = json3,
                phone = 0955666111,
                car = "bezn"
            };

            var jsonConver3 = JsonConvert.SerializeObject(json33);
        }
    }
}

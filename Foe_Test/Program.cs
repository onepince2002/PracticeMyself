using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Foe_Test
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    string payload1 = "{\"name\":400,\"male\":\"2\",\"tel\":\"error_code\",\"age\":\"3\"}";

        //    var apiError1 = JsonConvert.DeserializeObject<stId>(payload1);

        //    var decString = "5";

        //    var test = new student()
        //    {
        //        name = "eli",
        //        male = 2,
        //        //dec = decString;
        //    };

        //    Console.WriteLine(apiError1);
        //}


        //toDecimal轉型
        private static decimal? toDecimal(string a)
        {
            try
            {
                if (a != null) return Convert.ToDecimal(a);

                return null;
            }
            catch
            {
                throw new ArgumentException("請輸正確數字格式!!");
            }
        }

        public static string sql(string id)
        {
            id = null;
            List<SqlParameter> sqlParamList = new List<SqlParameter>();
            sqlParamList.Add(new SqlParameter()
            {
                ParameterName = "@id",
                Value = (object)id ?? DBNull.Value
            });
            ///將List<SqlParameter>轉換為SqlParameter[]
            SqlParameter[] sqlParams = sqlParamList.ToArray();

            return "";
        }
    }


    class student
    {
        public string name { get; set; }
        public int male { get; set; }
        public decimal dec { get; set; }
    }


    [JsonConverter(typeof(ApiConverter))]
    class stId : student
    {
        string add { get; set; }
        int age { get; set; }
    }

    //json_to_object
    public class ApiConverter : JsonConverter
    {
        private readonly Dictionary<string, string> _propertyMappings = new Dictionary<string, string>
        {
            {"tel", "add"}
        };

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsClass;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object instance = Activator.CreateInstance(objectType);
            var a = objectType.GetTypeInfo();

            var asas = objectType.GetProperties();
            var props = objectType.GetRuntimeProperties().ToList();//class
            var props1 = objectType.GetTypeInfo().DeclaredProperties.ToList();//class
            var aasdsas = objectType.IsAssignableFrom(objectType);




            JObject jo = JObject.Load(reader);//jso字川
            foreach (JProperty jp in jo.Properties())
            {
                //if (_propertyMappings.ContainsKey(jp.Name))
                //{
                //    var ad = _propertyMappings.Values;
                //    var ad1 = _propertyMappings.Keys;
                //}
                //if (!_propertyMappings.TryGetValue(jp.Name, out var name))
                //    name = jp.Name;

                string name = null;
                if (!_propertyMappings.ContainsKey(jp.Name))
                {
                    name = jp.Name;
                }
                else
                {
                    name = _propertyMappings.Values.First();
                }

                PropertyInfo prop = props.FirstOrDefault(pi => pi.CanWrite && pi.Name == name);
                if (prop != null)
                {
                    prop?.SetValue(instance, jp.Value.ToObject(prop.PropertyType, serializer));
                }
            }

            return instance;
        }
    }
}

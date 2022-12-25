using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ggwp
{
    internal class ewq
    {
        public static T Deserializer<T>(string path)
        {
            string json = File.ReadAllText(path);
            T List = JsonConvert.DeserializeObject<T>(json);
            return List;
        }
        public static void Serializer<T>(string path, T list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, json);
        }
    }
}
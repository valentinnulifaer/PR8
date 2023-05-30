using Newtonsoft.Json;
using Microsoft.Win32;
using System.IO;


namespace JsonLibb
{
    public class Json
    {
        public static void Serialize<T>(T msg)
        {
            string json = JsonConvert.SerializeObject(msg);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllText($"{desktop}\\message.txt", json);
        }

        public static T Deserialize<T>(string path)
        {
            string json = File.ReadAllText(path);
            T message = JsonConvert.DeserializeObject<T>(json);
            return message;
        }
    }
}
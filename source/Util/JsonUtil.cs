using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Util
{
    public class JsonUtil
    {
        public static string SerializeJson<T>(T obj) where T : class
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public static Stream SerializeJson<T>(T obj, Stream stream) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            serializer.WriteObject(stream, obj);
            return stream;
        }

        public static T DeserializeJson<T>(string json) where T : class
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return DeserializeJson<T>(stream);
            }
        }

        public static T DeserializeJson<T>(Stream stream) where T : class
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            var serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }
}

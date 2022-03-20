using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TranslatorToolsLibrary.DI;

namespace JSONSaveLoaderLibrary
{
    public class JSONSaveLoader<T> : IFileController<T>
    {
        public ICollection<T> Load(string path)
        {
            return Deserialize(path);
        }

        public void Save(ICollection<T> data, string path)
        {
            Serialize(data, path);
        }

        private void Serialize(ICollection<T> data, string path)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(path))
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data, typeof(ICollection<T>));
            }
        }

        private ICollection<T> Deserialize(string path)
        {
            if (File.Exists(path))
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
                };
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<T>>(File.ReadAllText(path), settings);
            }
            return new List<T>();//TODO fix that
        }


    }
}
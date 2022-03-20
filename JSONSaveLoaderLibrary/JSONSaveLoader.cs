using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TranslatorToolsLibrary.DI;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace JsonSaveLoaderLibrary
{
    public class JsonSaveLoader<T> : IFileController<T>, IAsyncFileController<T>
    {
        public void Save(ICollection<T> data, string path)
        {
            Serialize(data, path);
        }

        public ICollection<T> Load(string path)
        {
            return Deserialize(path);
        }

        public Task SaveAsync(ICollection<T> data, string path)
        {
            return Task.Run(() =>
            {
                Serialize(data, path);
            });
        }

        public Task<ICollection<T>> LoadAsync(string path)
        {

            return Task.Run(() =>
            {
                return Deserialize(path);
            });
        }

        private void Serialize(ICollection<T> data, string path)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.TypeNameHandling = TypeNameHandling.Auto;
                serializer.Formatting = Formatting.Indented;

                using (StreamWriter sw = new StreamWriter(path))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, data, typeof(ICollection<T>));
                }
            }
            catch (Exception ex)
            {
                // Todo add logger
                throw ex;
            }
        }

        private ICollection<T> Deserialize(string path)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore
                };
                return JsonConvert.DeserializeObject<ICollection<T>>(File.ReadAllText(path), settings);
            }
            catch (Exception ex)
            {
                // Todo add logger
                throw ex;
            }
        }
    }
}
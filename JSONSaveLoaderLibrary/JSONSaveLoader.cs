using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TranslatorToolsLibrary.DI;
using System.Threading.Tasks;
using System.Threading;

namespace JSONSaveLoaderLibrary
{
    public class JSONSaveLoader<T> : IFileController<T>, IAsyncFileController<T>
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
                var settings = new Newtonsoft.Json.JsonSerializerSettings
                {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
                };
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<T>>(File.ReadAllText(path), settings);
            }
            catch (Exception ex)
            {
                // Todo add logger
                throw ex;
            }
        }
    }
}
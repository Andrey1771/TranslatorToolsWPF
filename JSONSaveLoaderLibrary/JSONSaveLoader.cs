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
    public class JsonSaveLoader<T>/* : *//*IFileController<T>,*//* IAsyncFileController<T>*/
    {
        public T Load(string path)
        {
            return Deserialize(path);
            //return Deserialize(path);
        }

/*        public Task<ICollection<T>> LoadAsync(string path)
        {

            return Task.Run(() =>
            {
                return Load(path);
            });
        }*/

        public void Save(ICollection<T> data, string path)
        {
            Serialize(data, path);
        }

        public Task SaveAsync(ICollection<T> data, string path)
        {
            return Task.Run(() =>
            {
                Save(data, path);
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

        private T Deserialize(string path)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,
                    
                };

                var file = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(file, settings);
            }
            catch (Exception ex)
            {
                // Todo add logger
                throw ex;
            }
        }
    }
}
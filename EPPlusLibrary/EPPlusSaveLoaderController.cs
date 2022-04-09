using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorToolsLibrary.DI;

namespace EPPlusLibrary
{
    class EPPlusSaveLoaderController<T> : IFileController<T>, IAsyncFileController<T>
    {
        public ICollection<T> Load(string path)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> LoadAsync(string path)
        {
            throw new NotImplementedException();
        }

        public void Save(ICollection<T> data, string path)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(ICollection<T> data, string path)
        {
            throw new NotImplementedException();
        }
    }
}

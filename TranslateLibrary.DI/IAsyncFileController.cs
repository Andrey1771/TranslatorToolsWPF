using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI
{
    public interface IAsyncFileController<T>
    {
        Task SaveAsync(ICollection<T> data, string path);
        Task<ICollection<T>> LoadAsync(string path);
    }
}

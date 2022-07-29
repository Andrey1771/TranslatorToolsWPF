using System.Collections.Generic;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI
{
    public interface IAsyncFileController<T> // TODO Возможно он лишний
    {
        Task SaveAsync(ICollection<T> data, string path);
        Task<ICollection<T>> LoadAsync(string path);
    }
}

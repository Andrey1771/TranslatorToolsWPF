using System.Collections.Generic;

namespace TranslatorToolsLibrary.DI
{
    public interface IFileController<T>
    {
        void Save(ICollection<T> data, string path);
        ICollection<T> Load(string path);
    }
}

using System.Collections.Generic;

namespace TranslatorToolsLibrary.DI
{
    public interface ITranslatorFile<T>
    {
        void MergeFiles(ICollection<T> data);

        void UpdateFile(T file);
    }
}

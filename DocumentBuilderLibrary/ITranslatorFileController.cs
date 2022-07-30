using System.Collections.Generic;

namespace DocumentBuilderLibrary
{
    public interface ITranslatorFileController<T>
    {
        void Load(string path);
        void Save(string path);

        void MergeFiles(ICollection<T> data);
        void UpdateFile(T file);
    }
}

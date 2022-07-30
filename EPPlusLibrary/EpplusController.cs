using System.Collections.Generic;
using DocumentBuilderLibrary;
using TranslatorToolsLibrary.DI;

namespace EPPlusLibrary
{
    public class EpplusController<T> : ITranslatorFileController<T>
    {
        public void Load(string path)
        {
            throw new System.NotImplementedException();
        }
        public void Save(string path)
        {
            throw new System.NotImplementedException();
        }
        //public Task Export(Table table, string filePath);
        //public void Import(string filePath);

        public void MergeFiles(ICollection<T> data)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateFile(T file)
        {
            throw new System.NotImplementedException();
        }
    }
}

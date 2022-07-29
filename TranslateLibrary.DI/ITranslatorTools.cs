using System.Collections.Generic;
using TranslatorToolsLibrary.DI.Entities;

namespace TranslatorToolsLibrary.DI
{
    public interface ITranslatorTools
    {
        ICollection<IFileTranslation> FileTranslations { get; }
        public void SaveData(string path);
        public void LoadData(string path);
    }
}

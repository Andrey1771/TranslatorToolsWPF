using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI
{
    public interface ITranslatorTools
    {
        public void SaveData(string path);
        public void LoadData(string path);
    }
}

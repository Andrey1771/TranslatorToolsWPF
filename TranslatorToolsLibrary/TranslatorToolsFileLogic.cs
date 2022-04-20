using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorToolsLibrary.DI;

namespace TranslatorToolsLibrary.TranslatorToolsLibrary
{
    public class TranslatorFileLogic<T> : ITranslatorFileLogic<T> // TODO
    {
        public ICollection<T> LoadData(string path)
        {
            throw new NotImplementedException();
        }

        public void SaveData(ICollection<T> data)
        {
            throw new NotImplementedException();
        }
    }
}

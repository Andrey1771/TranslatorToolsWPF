using System;
using System.Collections.Generic;
using TranslatorToolsLibrary.DI;

namespace TranslatorToolsLibrary
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

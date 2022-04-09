using System;
using TranslatorToolsLibrary.DI;

namespace TranslatorToolsLibrary
{
    public class TranslatorTools : ITranslatorTools
    {
        ITranslatorFileLogic _fileLogic;

        TranslatorTools()
        {
            _fileLogic = new TranslatorFileLogic();
        }

        public void SaveData(string path)
        {

        }

        public void LoadData(string path)
        {

        }

    }
}

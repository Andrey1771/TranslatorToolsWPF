using JsonSaveLoaderLibrary;
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
        //where T : new()
        public void SaveData(string path)
        {
            var jsonController = new JsonSaveLoader<>
        }

        public void LoadData(string path)
        {
            
        }

    }
}

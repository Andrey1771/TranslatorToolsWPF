using System.Collections.Generic;
using TranslatorToolsLibrary.DI;
using TranslatorToolsLibrary.DI.Entities;
using TranslatorToolsLibrary.JsonSaveLoaderLibrary;
using TranslatorToolsLibrary.TranslatorToolsObjects;

namespace TranslatorToolsLibrary
{
    public class TranslatorTools : ITranslatorTools
    {
        //ITranslatorFileLogic _fileLogic;

        public ICollection<IFileTranslation> FileTranslations { get; private set; }

        public TranslatorTools()
        {
            //_fileLogic = new TranslatorFileLogic();
        }
        //where T : new()
        public async void SaveData(string path) // TODO добавить тип сохраняемого значения
        {
            var jsonController = new JsonSaveLoader<IFileTranslation>();
            await jsonController.SaveAsync(FileTranslations, path);
        }

        public async void LoadData(string path)
        {
            var jsonController = new JsonSaveLoader<FileTranslation>();
            var some = jsonController.Load(path);
            FileTranslations = new List<IFileTranslation>() { };
        }

    }
}

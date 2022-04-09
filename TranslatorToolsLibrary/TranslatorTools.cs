using JsonSaveLoaderLibrary;
using System;
using System.Collections.Generic;
using TranslatorToolsLibrary.DI;
using TranslatorToolsLibrary.DI.Entities;

namespace TranslatorToolsLibrary.TranslatorToolsLibrary
{
    public class TranslatorTools : ITranslatorTools
    {
        ITranslatorFileLogic _fileLogic;

        public ICollection<IFileTranslation> FileTranslations { get; private set; }

        TranslatorTools()
        {
            _fileLogic = new TranslatorFileLogic();
        }
        //where T : new()
        public async void SaveData(string path) // TODO добавить тип сохраняемого значения
        {
            var jsonController = new JsonSaveLoader<IFileTranslation>();
            await jsonController.SaveAsync(FileTranslations, path);
        }

        public async void LoadData(string path)
        {
            var jsonController = new JsonSaveLoader<IFileTranslation>();
            FileTranslations = await jsonController.LoadAsync(path);
        }

    }
}

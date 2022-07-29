using System.Collections.Generic;

namespace TranslatorToolsLibrary.DI
{
    public interface ITranslatorFileLogic<T>
    {
        public void SaveData(ICollection<T> data); // TODO Должен будет принимать тип как сохранить
        public ICollection<T> LoadData(string path);
    }
}

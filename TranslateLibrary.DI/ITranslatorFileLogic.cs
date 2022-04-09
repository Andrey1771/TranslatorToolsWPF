using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI
{
    public interface ITranslatorFileLogic<T>
    {
        public void SaveData(ICollection<T> data); // TODO Должен будет принимать тип как сохранить
        public ICollection<T> LoadData(string path);
    }
}

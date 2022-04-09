using System;
using System.Collections.Generic;
using TranslatorToolsLibrary.DI;

namespace EPPlusLibrary
{
    public class EPPlusFile<T> : ITranslatorFile<T>
    {
        EPPlusSaveLoaderController<T> saveLoaderController;

        EPPlusFile()
        {

        }

        public void MergeFiles(ICollection<T> data)
        {
            throw new NotImplementedException();
        }

        public void UpdateFile(T file)
        {
            throw new NotImplementedException();
        }
    }
}

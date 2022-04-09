using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI
{
    public interface ITranslatorFile<T>
    {
        void MergeFiles(ICollection<T> data);

        void UpdateFile(T file);
    }
}

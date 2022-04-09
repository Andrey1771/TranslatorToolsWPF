using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI.Entities
{
    public interface IChildren
    {
        ISource Source { get; set; }
        ITranslation Translation { get; set; }
        string Key { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI.Entities
{
    public interface IFileTranslation
    {
        int FormatVersion { get; set; }
        string Namespace { get; set; }
        IEnumerable<IChildren> Children { get; set; }
        IEnumerable<ISubnamespaces> Subnamespaces { get; set; }
    }
}

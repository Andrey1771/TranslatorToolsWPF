using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorToolsLibrary.DI.Entities;

namespace TranslatorToolsLibrary.TranslatorToolsObjects
{
    public class FileTranslation : IFileTranslation
    {
        public int FormatVersion { get; set; }
        public string Namespace { get; set; }
        public IEnumerable<IChildren> Children { get; set; }
        public IEnumerable<ISubnamespaces> Subnamespaces { get; set; }
    }
}

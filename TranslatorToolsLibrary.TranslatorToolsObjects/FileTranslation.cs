using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorToolsLibrary.DI.Entities;

namespace TranslatorToolsLibrary.TranslatorToolsObjects
{
    public class FileTranslation /*: IFileTranslation*/
    {
        public int FormatVersion { get; set; }
        public string Namespace { get; set; }
        public List<Children> Children { get; set; }
        public List<Subnamespaces> Subnamespaces { get; set; }

        public FileTranslation(int formatVersion = default, string aNamespace = default, List<Children> children = default, List<Subnamespaces> subnamespaces = default)
        {
            FormatVersion = formatVersion;
            Namespace = aNamespace;
            Children = children;
            Subnamespaces = subnamespaces;
        }
    }
}

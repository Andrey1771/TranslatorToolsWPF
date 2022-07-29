using System.Collections.Generic;

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

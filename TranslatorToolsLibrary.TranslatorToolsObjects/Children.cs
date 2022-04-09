using System;
using TranslatorToolsLibrary.DI.Entities;

namespace TranslatorToolsLibrary.TranslatorToolsObjects
{
    public class Children : IChildren
    {
        public ISource Source { get; set; }
        public ITranslation Translation { get; set; }
        public string Key { get; set; }
    }
}

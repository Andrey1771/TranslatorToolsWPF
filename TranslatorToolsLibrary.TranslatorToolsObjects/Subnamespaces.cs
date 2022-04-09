using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorToolsLibrary.DI.Entities;

namespace TranslatorToolsLibrary.TranslatorToolsObjects
{
    public class Subnamespaces : ISubnamespaces
    {
        public string Namespace { get; set; }
        public IChildren Children { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI.Logger
{
    public interface ILogMessage
    {
        Exception Exception { get; set; }
        string Message { get; set; }
        DateTime DateTime { get; set; }
    }
}

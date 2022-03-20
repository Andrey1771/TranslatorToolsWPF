using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI.Logger
{
    public interface ILogger : ILogMessageCreator
    {
        void WriteInformation();
        void WriteWarning();
        void WriteError();

        protected ILoggerHandler LoggerHandler { get; set; }
    }
}

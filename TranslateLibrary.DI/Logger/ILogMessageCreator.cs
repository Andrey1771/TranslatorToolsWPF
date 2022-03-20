using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI.Logger
{
    public interface ILogMessageCreator
    {
        ILogMessage CreateMessage(Exception Exception, string Message, DateTime DateTime);
    }
}

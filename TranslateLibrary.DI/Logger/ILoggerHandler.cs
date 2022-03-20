using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI.Logger
{
    public interface ILoggerHandler
    {
        public delegate void EventHandler(ILogMessage message);
        public event EventHandler Notify;
    }
}

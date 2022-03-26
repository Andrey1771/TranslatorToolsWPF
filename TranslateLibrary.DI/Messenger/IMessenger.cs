using EventBusLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI.IMessenger
{
    public interface IMessenger : IGlobalSubscriber
    {
        void CreateMessage(string Message, DateTime DateTime, Exception Exception = null);
        void CreateWarningMessage(string Message, DateTime DateTime, Exception Exception = null);
        void CreateExceptionMessage(string Message, DateTime DateTime, Exception Exception = null);
    }
}

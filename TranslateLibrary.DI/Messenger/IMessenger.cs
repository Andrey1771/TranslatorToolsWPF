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
        void CreateMessage(string message, DateTime dateTime, Exception exception = null);
        void CreateWarningMessage(string message, DateTime dateTime, Exception exception = null);
        void CreateExceptionMessage(string message, DateTime dateTime, Exception exception = null);
    }
}

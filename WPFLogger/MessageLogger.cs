using System;
using TranslatorToolsLibrary.DI.IMessenger;

namespace MessageLoggerLibrary
{
    public class MessageLogger : IMessenger
    {


        MessageLogger()
        {

        }

        public void CreateExceptionMessage(string Message, DateTime DateTime, Exception Exception = null)
        {
            throw new NotImplementedException();
        }

        public void CreateMessage(string Message, DateTime DateTime, Exception Exception = null)
        {
            throw new NotImplementedException();
        }

        public void CreateWarningMessage(string Message, DateTime DateTime, Exception Exception = null)
        {
            throw new NotImplementedException();
        }
    }
}

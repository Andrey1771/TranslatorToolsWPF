using EventBusLibrary;
using System;

namespace TranslatorToolsLibrary.DI.Messenger
{
    public interface IMessenger : IGlobalSubscriber
    {
        void CreateMessage(string message, DateTime dateTime, Exception exception = null);
        void CreateWarningMessage(string message, DateTime dateTime, Exception exception = null);
        void CreateExceptionMessage(string message, DateTime dateTime, Exception exception = null);
    }
}

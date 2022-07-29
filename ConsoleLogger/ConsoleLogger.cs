using System;
using TranslatorToolsLibrary.DI.Messenger;

namespace ConsoleLoggerLibrary
{
    public class ConsoleLogger : IMessenger
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void CreateExceptionMessage(string message, DateTime dateTime, Exception exception = null)
        {
            throw new NotImplementedException();
        }

        public void CreateMessage(string message, DateTime dateTime, Exception exception = null)
        {
            throw new NotImplementedException();
        }

        public void CreateWarningMessage(string message, DateTime dateTime, Exception exception = null)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using TranslatorToolsLibrary.DI.IMessenger;

namespace ConsoleLoggerLibrary
{
    public class ConsoleLogger : IMessenger
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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

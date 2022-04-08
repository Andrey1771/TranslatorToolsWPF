using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TranslatorToolsLibrary.DI.IMessenger;
using TranslatorToolsWPF.Models;

namespace TranslatorToolsWPF.ViewModels
{
    class MessageLoggerViewModel : DependencyObject, IMessenger
    {
        public IEnumerable<MessageLogger> MessagesLogger;

        public MessageLoggerViewModel(IEnumerable<MessageLogger> messagesLogger)
        {
            MessagesLogger = messagesLogger;
        }

        public string Messages
        {
            get { return (string)GetValue(MessagesProperty); }
            set { SetValue(MessagesProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessagesProperty =
            DependencyProperty.Register("Messages", typeof(List), typeof(MessageLoggerViewModel), new PropertyMetadata(default(string)));

        public DateTime DateTime
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for DateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateTimeProperty =
            DependencyProperty.Register("DateTime", typeof(DateTime), typeof(MessageLoggerViewModel), new PropertyMetadata(default(DateTime)));

        public Exception Exception
        {
            get { return (Exception)GetValue(ExceptionProperty); }
            set { SetValue(ExceptionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Exception.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExceptionProperty =
            DependencyProperty.Register("Exception", typeof(Exception), typeof(MessageLoggerViewModel), new PropertyMetadata(default(Exception)));


        public void CreateExceptionMessage(string message, DateTime dateTime, Exception exception = null) => UpdateMessage(message, dateTime, exception);

        public void CreateMessage(string message, DateTime dateTime, Exception exception = null) => UpdateMessage(message, dateTime, exception);

        public void CreateWarningMessage(string message, DateTime dateTime, Exception exception = null) => UpdateMessage(message, dateTime, exception);

        private void UpdateMessage(string message, DateTime dateTime, Exception exception)
        {
            Message = message;
            DateTime = dateTime;
            Exception = exception;
        }
    }
}

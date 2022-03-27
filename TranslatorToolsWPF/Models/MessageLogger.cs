using System;
using TranslatorToolsLibrary.DI.IMessenger;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TranslatorToolsWPF.Models
{
    public class MessageLogger : INotifyPropertyChanged, IMessenger
    {
        private string _message;
        private DateTime _dateTime;
        private Exception _exception;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message"); // Можно получить из Type, но медленней
            }
        }

        public DateTime DateTime
        {
            get { return _dateTime; }
            set
            {
                _dateTime = value;
                OnPropertyChanged("DateTime"); // Можно получить из Type, но медленней
            }
        }

        public Exception Exception
        {
            get { return _exception; }
            set
            {
                _exception = value;
                OnPropertyChanged("Exception"); // Можно получить из Type, но медленней
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

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

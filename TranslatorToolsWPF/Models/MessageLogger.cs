using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TranslatorToolsWPF.Models
{
    public class MessageLogger : INotifyPropertyChanged
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
    }
}

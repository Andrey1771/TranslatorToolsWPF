using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TranslatorToolsWPF.Models;

namespace TranslatorToolsWPF.ViewModels
{
    class MessageLoggerViewModel : DependencyObject
    {
        public MessageLogger MessageLogger;

        public MessageLoggerViewModel(MessageLogger messageLogger)
        {
            MessageLogger = messageLogger;
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(int), typeof(MessageLoggerViewModel), new PropertyMetadata(default(string)));

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
    }
}

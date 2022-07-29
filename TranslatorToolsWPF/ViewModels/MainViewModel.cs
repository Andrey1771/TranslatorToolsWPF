using System.Collections.Generic;
using System.Collections.ObjectModel;
using TranslatorToolsWPF.Models;

namespace TranslatorToolsWPF.ViewModels
{
    class MainViewModel
    {
        ObservableCollection<MessageLoggerViewModel> MessagesLoggerList { get; set; }

        public MainViewModel(IEnumerable<MessageLogger> messagesLogger)
        {
            //MessagesLoggerList = new ObservableCollection<MessageLoggerViewModel>(messagesLogger.Select(b => new MessageLoggerViewModel(b)));
        }
    }
}

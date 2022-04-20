using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

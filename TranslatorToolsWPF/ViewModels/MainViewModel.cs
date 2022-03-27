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
        ObservableCollection<MessageLoggerViewModel> MessageLoggerList { get; set; }

        public MainViewModel(List<MessageLogger> messageLoggers) 
        {
            MessageLoggerList = new ObservableCollection<MessageLoggerViewModel>(messageLoggers.Select(m => new MessageLoggerViewModel(m)));
        }
    }
}

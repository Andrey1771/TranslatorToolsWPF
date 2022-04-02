using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TranslatorToolsWPF.Views
{
    /// <summary>
    /// Interaction logic for MessageLoggerView.xaml
    /// </summary>
    public partial class MessageLoggerView : UserControl
    {
        public MessageLoggerView()
        {
            InitializeComponent();
        }

        private void SwitchLoggerButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (LoggerTextBlock.Visibility == Visibility.Visible)
            {
                LoggerTextBlock.Visibility = Visibility.Collapsed;
                button.Content = "Отобразить логгер"; // TODO Скорое всего в будущем придется поменять
            }
            else
            {
                LoggerTextBlock.Visibility = Visibility.Visible;
                button.Content = "Скрыть логгер";
            }
        }
    }
}

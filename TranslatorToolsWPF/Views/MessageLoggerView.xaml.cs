using System.Windows;
using System.Windows.Controls;

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

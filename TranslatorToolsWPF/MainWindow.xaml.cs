﻿using HttpClientLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using TranslatorToolsLibrary;
using TranslatorToolsWPF.Models;
using TranslatorToolsWPF.ViewModels;

namespace TranslatorToolsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClientController _clientController;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _clientController = new HttpClientController();


            DataContext = new MainViewModel(new List<MessageLogger>() { new MessageLogger() }); // Создали ViewModel
            //var logSystem = new MessageLogger();
            //var console = new ConsoleLogger();
        }

        // Кажется, что есть событие лучше
        private async void IdentifiersTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!IsTextAllowed(textBox.Text))
            {
                textBox.Text = RemoveInvalidSymbols(textBox.Text);
            }
            var translatorTools = new TranslatorTools();
            translatorTools.LoadData(@"F:\Тестовые_Задания\Тестовое The Most Games\Task2\batch07-de.loc");
            var res = await _clientController.GetAsync();
        }

        private static readonly Regex _regex = new("^([(0-9)]+,)+"); // regex that matches disallowed text new("[+((0-9)+?(,))]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private static string RemoveInvalidSymbols(string text)
        {
            return _regex.Replace(text, "");
        }




        private StringBuilder CreateMessage(string message, DateTime dateTime, Exception exception)
        {
            var messageBuilder = new StringBuilder();

            messageBuilder.AppendLine($"{dateTime:G} {message}"); // TODO Планируется усложнить
            messageBuilder.AppendLine(exception.Message);

            return messageBuilder;
        }
    }
}

﻿using HttpClientControllerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
            SetInitialSettings();
        }

        private void SetInitialSettings()
        {
            _clientController = new HttpClientController();
        }

        //Кажется, что есть событие лучше
        private async void IdentifiersTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!IsTextAllowed(textBox.Text))
            {
                textBox.Text = RemoveInvalidSymbols(textBox.Text);
            }
            var res = await _clientController.GetAsync();
        }

        private static readonly Regex _regex = new("^([(0-9)]+,)+"); //regex that matches disallowed text new("[+((0-9)+?(,))]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private static string RemoveInvalidSymbols(string text)
        {
            return _regex.Replace(text, "");
        }

    }
}
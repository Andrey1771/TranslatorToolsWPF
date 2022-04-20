using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorToolsLibrary.DI.Entities;

namespace TranslatorToolsLibrary.TranslatorToolsObjects
{
    public class Source : ISource
    {
        public string Text { get; set; }

        public Source(string text = default)
        {
            Text = text;
        }
    }
}

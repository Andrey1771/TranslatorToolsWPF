using TranslatorToolsLibrary.DI.Entities;

namespace TranslatorToolsLibrary.TranslatorToolsObjects
{
    public class Translation : ITranslation
    {
        public string Text { get; set; }

        public Translation(string text = default)
        {
            Text = text;
        }
    }
}

namespace TranslatorToolsLibrary.TranslatorToolsObjects
{
    public class Children /*: IChildren*/
    {
        public Source Source { get; set; }
        public Translation Translation { get; set; }
        public string Key { get; set; }

        public Children(Source source = default, Translation translation = default, string key = default)
        {
            Source = source;
            Translation = translation;
            Key = key;
        }
    }
}

namespace TranslatorToolsLibrary.DI.Entities
{
    public interface IChildren
    {
        ISource Source { get; set; }
        ITranslation Translation { get; set; }
        string Key { get; set; }
    }
}

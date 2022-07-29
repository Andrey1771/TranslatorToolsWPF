namespace TranslatorToolsLibrary.DI.Entities
{
    public interface ISubnamespaces
    {
        string Namespace { get; set; }
        IChildren Children { get; set; }
    }
}

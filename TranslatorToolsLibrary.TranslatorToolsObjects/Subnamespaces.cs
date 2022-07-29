namespace TranslatorToolsLibrary.TranslatorToolsObjects
{
    public class Subnamespaces /*: ISubnamespaces*/
    {
        public string Namespace { get; set; }
        public Children Children { get; set; }

        public Subnamespaces(string aNamespace = default, Children children = default)
        {
            Namespace = aNamespace;
            Children = children;
        }
    }
}

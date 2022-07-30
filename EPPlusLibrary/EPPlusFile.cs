using System;
using System.Collections.Generic;
using DocumentBuilderLibrary;

namespace EPPlusLibrary
{
    public class EPPlusFile<T> : IFile
    {
        EPPlusSaveLoaderController<T> _saveLoaderController; // TODO Refactoring links for project
        IPart _filePart = new EPPLusPart();

        EPPlusFile()
        {
            
        }

        public void AddPart(IPart part)
        {
            _filePart.MergePart(part);
        }

        public void RemovePart(IPart part)
        {
            _filePart.RemovePart(part);
        }
    }
}

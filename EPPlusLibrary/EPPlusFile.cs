using System;
using System.Collections.Generic;
using DocumentBuilderLibrary.Interfaces;
using DocumentBuilderLibrary.Interfaces.Strategies;
using EPPlusLibrary.Strategies;

namespace EPPlusLibrary
{
    public class EPPlusFile<T> : IFile
    {
        // TODO Refactoring links for project
        IPart _filePart = new EPPLusPart();

        EPPlusFile()
        {
            
        }

        public void AddPart(IPart part)
        {
            _filePart.MergePart(part, new AddEpplusStrategy());
        }

        public void RemovePart(IPart part)
        {
            _filePart.RemovePart(part);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentBuilderLibrary.Interfaces;
using DocumentBuilderLibrary.Interfaces.Strategies;

namespace EPPlusLibrary.Strategies
{
    public class AddEpplusStrategy : IAddStrategy
    {
        public void Execute(IFile file, IPart part)
        {
            file.AddPart(part);
        }
    }
}

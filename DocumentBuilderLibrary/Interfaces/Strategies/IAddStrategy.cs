using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentBuilderLibrary.Interfaces.Strategies
{
    public interface IAddStrategy
    {
        void Execute(IFile file, IPart part);
    }
}

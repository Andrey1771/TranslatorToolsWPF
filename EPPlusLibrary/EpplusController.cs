using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlusLibrary
{
    public class EpplusController
    {
        public Task Export(ExcelTable table, string filePath);
        public void Import(string filePath);
    }
}

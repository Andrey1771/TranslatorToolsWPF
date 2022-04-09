﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorToolsLibrary.DI.Entities
{
    public interface ISubnamespaces
    {
        string Namespace { get; set; }
        IChildren Children { get; set; }
    }
}
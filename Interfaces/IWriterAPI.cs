﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IWriterAPI
    {
        bool WriteDefaultMessage();
        bool WriteCustomMessage(string message);
    }
}

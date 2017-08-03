using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Classes
{
    public abstract class BaseWriter : IWriter
    {
        public abstract bool Write(string message);
    }
}

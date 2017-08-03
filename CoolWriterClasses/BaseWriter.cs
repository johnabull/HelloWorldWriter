using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Classes
{
    //We could add common functionality, default behavior etc. to this class
    //Implements IWriter
    public abstract class BaseWriter : IWriter
    {
        public abstract bool Write(string message);
    }
}

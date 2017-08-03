using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Classes
{
    public class DatabaseWriter : BaseWriter
    {
        public override bool Write(string message)
        {
            try
            {
                //Do database writing here...
                return true;
            }
            catch(Exception e)
            {
                //do some sort of logging here.  The foollowing line is just to prevent "e is not used warning"
                Console.Write(e.Message);
                return false;
            }
        }
    }
}

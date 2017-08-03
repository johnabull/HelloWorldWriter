using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Classes
{
    public class ConsoleWriter : BaseWriter
    {
        public override bool Write(string message)
        {
            try
            {
                Console.Write(message);
                Console.ReadKey();
                return true;
            }
            catch(Exception e)
            {
                //you would do some sort of logging here.  The foollowing line is just to prevent "e is not used warning"
                Console.Write(e.Message);
                return false;
            }
        }
    }
}

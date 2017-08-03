using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Classes
{
    //A concrete implementation of a Writer
    //Just writes to a console
    public class ConsoleWriter : BaseWriter
    {
        public override bool Write(string message)
        {
            try
            {
                Console.Write(message);
                //Just to stop it so we can see the text on the console...
                Console.ReadKey();
                return true;
            }
            catch(Exception e)
            {
                //You would probably do some sort of logging here, or some other more robust error handling
                //The foollowing line is just to prevent "e is not used warning"
                Console.Write(e.Message);
                return false;
            }
        }
    }
}

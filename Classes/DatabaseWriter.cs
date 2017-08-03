using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Classes
{
    //A concrete implementation of a Writer
    //Would write to a DB table
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
                //You would want to do some sort of logging here, or some other more robust error handling
                //The foollowing line is just to prevent "e is not used warning"
                Console.Write(e.Message);
                return false;
            }
        }
    }
}

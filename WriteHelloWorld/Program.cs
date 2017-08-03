using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace WriteHelloWorld
{
    class Program : IWriter
    {
        static void Main(string[] args)
        {
            
        }

        public bool Write(string message)
        {
            try 
            { 
                Console.Write(message);
                return false;
            }
            catch(Exception e)
            {
                //log exception or something
                return false;
            }
        }
    }
}

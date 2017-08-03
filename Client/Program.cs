using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API;

namespace CoolWriterRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var writerAPI = new WriterAPI();
            writerAPI.WriteDefaultMessage();
            writerAPI.WriteCustomMessage("Hello Universe");
        }
    }
}

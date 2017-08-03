using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Classes
{
    public class Resolver : IResolver
    {
        public IWriter ResolveWriter(int writerTypeId)
        {
            //Get the correct Writer instance based on Writer Type Id
            switch (writerTypeId)
            {
                case 1:
                    return new ConsoleWriter();
                case 2:
                    return new DatabaseWriter();
                default:
                    return new ConsoleWriter();
            }
        }
    }
}

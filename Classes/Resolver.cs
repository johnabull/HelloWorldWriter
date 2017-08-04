using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Classes
{
    //A concrete implementation of a Resolver
    public class Resolver : IResolver
    {
        /// <summary>
        /// Uses writer type Id to instantiate a particular Writer
        /// </summary>
        /// <param name="writerTypeId">Id of the writer to instantiate</param>
        /// <returns>A writer instance</returns>
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

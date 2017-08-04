using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Classes;

namespace API
{
    public class WriterAPI : IWriterAPI
    {
        //Gets set via dependency injection
        public IConfigurationReader ConfigurationReader { get; set; }
        public IResolver Resolver { get; set; }

        /// <summary>
        /// API Constructor
        /// </summary>
        public WriterAPI()
        {
            //Resolve Configuration Reader instance using structure map
            var container = new StructureMapConfiguration().container;
            container.BuildUp(this);
        }        

        /// <summary>
        /// Write default message from configuration
        /// </summary>
        /// <returns>Returns True if message written</returns>
        public bool WriteDefaultMessage()
        {
            var writer = Resolver.ResolveWriter(ConfigurationReader.WriterTypeId);
            return writer.Write(ConfigurationReader.DefaultMessage);
        }

        /// <summary>
        /// Write a cusom message
        /// </summary>
        /// <param name="message">Message to output/save</param>
        /// <returns>Returns True if message written</returns>
        public bool WriteCustomMessage(string message)
        {
            var writer = Resolver.ResolveWriter(ConfigurationReader.WriterTypeId);
            if (string.IsNullOrEmpty(message))
                return writer.Write(ConfigurationReader.DefaultMessage);
            else
                return writer.Write(message);
        }
    }
}

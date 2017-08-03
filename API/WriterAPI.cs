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
        IConfigurationReader ConfigurationReader { get; set; }
        //Gets set based on configured Writer Type Id
        IWriter Writer { get; set; }

        public WriterAPI()
        {
            //Resolve Configuration Reader instance using structure map
            var container = new StructureMapConfiguration().container;
            ConfigurationReader = container.GetInstance<IConfigurationReader>();
            //Get the correct Writer instance based on Writer Type Id
            switch(ConfigurationReader.WriterTypeId)
            {
                case 1:
                    Writer = new ConsoleWriter();
                    break;
                case 2:
                    Writer = new DatabaseWriter();
                    break;
                default:
                    Writer = new ConsoleWriter();
                    break;
            }
        }

        public bool WriteDefaultMessage()
        {
            return Writer.Write(ConfigurationReader.DefaultMessage);
        }

        public bool WriteCustomMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                message = ConfigurationReader.DefaultMessage;
            return Writer.Write(message);
        }
    }
}

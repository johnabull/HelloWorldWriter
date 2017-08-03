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
        //Set via dependency injection... structure map or the like
        public IConfigurationReader ConfigurationReader { get; set; }
        IWriter Writer { get; set; }

        public WriterAPI()
        {
            //For now, since we don't have our IOC Container configured...
            var container = new StructureMapConfiguration().container;
            ConfigurationReader = container.GetInstance<IConfigurationReader>();
            //Set Writer instance from config
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Configuration;

namespace Classes
{
    //A concrete implementation of the IConfigurationReader interface
    //Gives you all your necessary config options by reading them from an App.config file
    public class ConfigFileReader : IConfigurationReader
    {
        public int WriterTypeId { get; set; }
        public string DefaultMessage { get; set; }

        public ConfigFileReader()
        {
            //Try to get the writer Type Id from the config file
            int writerTypeId = 0;
            if (int.TryParse(ConfigurationManager.AppSettings["WriterTypeId"], out writerTypeId))
                WriterTypeId = writerTypeId;
            else
                throw new Exception("Invalid Writer Type Id");

            DefaultMessage = ConfigurationManager.AppSettings["DefaultMessage"];
        }
    }
}

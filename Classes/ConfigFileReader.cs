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
    //Provides all necessary config options by reading them from an App.config file
    public class ConfigFileReader : IConfigurationReader
    {
        public int WriterTypeId 
        { 
            get
            {
                int writerTypeId = 0;
                int.TryParse(ConfigurationManager.AppSettings["WriterTypeId"], out writerTypeId);
                    
                return writerTypeId;
            }
        }

        public string DefaultMessage
        {
            get
            {
                return ConfigurationManager.AppSettings["DefaultMessage"];
            }
        }

        public ConfigFileReader()
        {
            
        }
    }
}

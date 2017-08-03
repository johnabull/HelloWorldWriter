using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Configuration;

namespace Classes
{
    public class ConfigFileReader : IConfigurationReader
    {
        public int WriterTypeId { get; set; }
        public string DefaultMessage { get; set; }

        public ConfigFileReader()
        {
            int writerTypeId = 0;
            if (int.TryParse(ConfigurationManager.AppSettings["WriterTypeId"], out writerTypeId))
                WriterTypeId = writerTypeId;
            else
                throw new Exception("Invalid Writer Type Id");

            DefaultMessage = ConfigurationManager.AppSettings["DefaultMessage"];
        }
    }
}

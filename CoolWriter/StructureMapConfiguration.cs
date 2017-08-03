using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using Classes;
using Interfaces;

namespace API
{
    public class StructureMapConfiguration
    {
        public Container container { get; set; }
        public StructureMapConfiguration()
        {
            container = new Container(x =>
            {
                x.For<IConfigurationReader>().Use<ConfigFileReader>();

                x.Policies.SetAllProperties(y =>
                {
                    y.OfType<IConfigurationReader>();
                });
            });
        }
    }
}

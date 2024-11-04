using System;
using System.Collections.Generic;
using Mandatory2DGameFramework.worlds;
using Mandatory2DGameFramework.model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Mandatory2DGameFramework.model.Cretures;

namespace Mandatory2DGameFramework
{
    public class ConfigReader
    {
        private static ConfigReader instance;
        private XDocument xmlConfig;

        private ConfigReader(string path)
        {
            xmlConfig = XDocument.Load(path);
        }

        /// <summary>
        /// Ensure singleton initialization of the config reader
        /// </summary>
        public static ConfigReader Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new InvalidOperationException("An instance of ConfigReader has not been initialized");
                }
                return instance;
            }
        }

        /// <summary>
        /// Ensure singleton initialization of the config reader
        /// </summary>
        /// <param name="path">Filepath for the XML</param>
        public static void Initialize(string path)
        {
            if (instance == null)
            {
                instance = new ConfigReader(path);
            }
        }

        public XDocument ReturnConfig()
        {
            return xmlConfig;
        }
    }
}

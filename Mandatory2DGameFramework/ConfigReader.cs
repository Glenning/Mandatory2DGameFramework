using System;
using System.Collections.Generic;
using Mandatory2DGameFramework.worlds;
using Mandatory2DGameFramework.model;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model.Creatures;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Mandatory2DGameFramework
{
    public class ConfigReader
    {
        private static ConfigReader instance;
        private XDocument xmlConfig;

        /// <summary>
        /// Using XML Linq, reading an XML document
        /// </summary>
        /// <param name="path">Filepath for the XML</param>
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

        /// <summary>
        /// Configuration of World via XML file
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException">If the XML does not contain data for world, throw exception</exception>
        public (int MaxX, int MaxY) ConfigWorld()
        {
            var worldConfig = xmlConfig.Descendants("World").FirstOrDefault();
            if (worldConfig != null)
            {
                int MaxX = int.Parse(worldConfig.Element("Length").Value);
                int MaxY = int.Parse(worldConfig.Element("Height").Value);
                Console.WriteLine($"Game world created with the following Length: {MaxX} and Height: {MaxY}");
                return (MaxX, MaxY);
            }
            else
            {
                throw new InvalidDataException("Cannot create world with these parameters");
            }
        }

        //public void ConfigCreatures(World world) maybe not worth configuring xml for creatures
        //{
        //    foreach (var creature in xmlConfig.Descendants("Creature"))
        //    {
        //        string name = creature.Element("CreatureName").Value;
        //        string type = creature.Element("Type").Value;
        //        int hitpoint = int.Parse(creature.Element("HitPoint").Value);
        //        Creature addCreature = new Creature(name, type, hitpoint);
        //    }
        //}
    }
}

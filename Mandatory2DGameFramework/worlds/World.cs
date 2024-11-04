using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mandatory2DGameFramework.worlds
{
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        private List<WorldObject> _worldObjects;
        private List<Creature> _creatures;
        private static readonly MyLogger Logger = new MyLogger();

        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();

            var config = ConfigReader.Instance.ReturnConfig();
        }

        public void InitializeConfig(XDocument conf)
        {
            var worldConfig = conf.Descendants("World").FirstOrDefault();
            if (worldConfig != null)
            {

                MaxX = int.Parse(worldConfig.Element("Length").Value);
                MaxY = int.Parse(worldConfig.Element("Height").Value);
                Console.WriteLine($"Game world created with the following Length: {MaxX} and Height: {MaxY}");
            }
            foreach (var creature in conf.Descendants("Creature"))
            {
                string name = creature.Element("CreatureName").Value;
                string type = creature.Element("Type").Value;
            }
        }
        public override string ToString()
        {
            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}}}";
        }
    }
}

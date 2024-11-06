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

        public World()
        {
            var conf = ConfigReader.Instance;
            (MaxX, MaxY) = conf.ConfigWorld();
            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();

            conf.ConfigCreatures(this);
        }

        public override string ToString()
        {
            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}}}";
        }
    }
}

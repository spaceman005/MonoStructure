using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameStructure.Models
{
    public abstract class GameObject
    {
        public Vector3 Position { get; set; }
        public bool IsActive { get; set; }
        [XmlIgnore]
        public BoundingSphere BoundingSphere { get; set; }

        public GameObject()
        {
        }
    }
}

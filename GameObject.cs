using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStructure.Models
{
    public class GameObject
    {
        public Model Model { get; set; }
        public Vector3 Position { get; set; }
        public bool IsActive { get; set; }
        public BoundingSphere BoundingSphere { get; set; }

        public GameObject()
        {
            Model = null;
            Position = Vector3.Zero;
            IsActive = false;
            BoundingSphere = new BoundingSphere();
        }
    }
}

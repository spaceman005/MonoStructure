using GameStructure.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameStructure
{
    [Serializable]
    public class Sprite
    {
        public string name { get; set; }
        public string pathtotexture { get; set; }
        public Vector2 position { get; set; }

        private float Velocity = 3.0f;
        private Texture2D texture;

        public Sprite()
        {
        }

        public virtual void LoadContent(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>(pathtotexture);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
using GameStructure.Managers;
using Microsoft.Xna.Framework;
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
    public class Actor
    {
        public string name {  get; set; }
        public string pathtotexture { get; set; }
        public Vector2 position { get; set; }
        private Vector2 newpos;
        private float Velocity = 3.0f;
        public Actor() 
        {
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                newpos = new Vector2(position.X + 10, position.Y + 10);
                position = newpos;
            }
        }
    }
}

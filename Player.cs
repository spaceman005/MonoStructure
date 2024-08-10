using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameStructure.Models
{
    [Serializable]
    public class Player : Sprite
    {
        [XmlIgnore]
        protected Vector2 newpos;

        public Player() : base()
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override void Update(GameTime gametime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                newpos = new Vector2(position.X , position.Y - 10);
                position = newpos;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                newpos = new Vector2(position.X, position.Y + 10);
                position = newpos;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                newpos = new Vector2(position.X+10, position.Y);
                position = newpos;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                newpos = new Vector2(position.X-10, position.Y);
                position = newpos;
            }
        }
    }
}

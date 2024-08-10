using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameStructure.UI
{
    [Serializable]
    public class Button : Component
    {
        private MouseState currentMouse;
        private MouseState previousMouse;
        private bool isHovering;

        public Vector2 position { get; set; }
        [XmlIgnore]
        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }
        public string buttonText { get; set; }

        [XmlIgnore]
        public Texture2D texture;
        [XmlIgnore]
        public SpriteFont font;
        [XmlIgnore]
        public EventHandler Click;
        [XmlIgnore]
        public Color PenColor { get; set; }
        [XmlIgnore]
        public bool isClicked { get; private set; }


        private Button()
        {
        }
        public Button(Texture2D _texture, SpriteFont _font)
        {
            texture = _texture;
            font = _font;
            PenColor = Color.Black;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var color = Color.White;

            if (isHovering )
            {
                color = Color.Blue;
            }

            spriteBatch.Draw(texture, position, color);
            if (!string.IsNullOrEmpty(buttonText)) 
            {
                var x = (rectangle.X + (rectangle.Width / 2)) - (font.MeasureString(buttonText).X / 2);
                var y = (rectangle.Y + (rectangle.Height / 2)) - (font.MeasureString(buttonText).Y / 2);
                //draw text
                spriteBatch.DrawString(font, buttonText, new Vector2(x, y), Color.Black);
            }
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);
            //check hitboxes
            isHovering = false;
            if (mouseRectangle.Intersects(rectangle))
            {
                isHovering = true;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}

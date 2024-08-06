using GameStructure.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameStructure.GameStates
{
    public class GameplayState : State
    {
        private Texture2D _pokemon;
        public Vector2 _position = new Vector2(0,0);
        public Actor _actor;

        public GameplayState(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void Initialize()
        {
            _actor = new Actor() { name = "moveable", position = _position, pathtotexture = "phanpy"};
        }

        public override void LoadContent(ContentManager content)
        {
            _pokemon = content.Load<Texture2D>(_actor.pathtotexture);
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            _actor.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                XMLManager.Save(Globals.PATH + "phanpy.xml", _actor);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.MistyRose);

            spriteBatch.Begin();
            _actor.Draw(spriteBatch, _pokemon);
            spriteBatch.End();
        }

    }
}

using GameStructure.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameStructure.GameStates
{
    public class MenuState : State
    {
        public MenuState(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void Initialize()
        {
        }

        public override void LoadContent(ContentManager content)
        {
        }

        public override void UnloadContent()
        {
        }
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                StateManager.Instance.AddScreen(new GameplayState(_graphicsDevice));
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.Azure);

            spriteBatch.Begin();
            spriteBatch.End();
        }
    }
}

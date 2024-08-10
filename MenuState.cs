using GameStructure.Managers;
using GameStructure.UI;
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
        Texture2D buttontexture;
        SpriteFont spritefont;
        Button button1;
        public MenuState(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void Initialize()
        {
        }

        public override void LoadContent(ContentManager content)
        {
            buttontexture = content.Load<Texture2D>("buttontex");
            spritefont = content.Load<SpriteFont>("File");

            button1 = XMLManager.Load<Button>($"Content/buttondata.xml");
            button1.texture = buttontexture;
            button1.font = spritefont;

            button1.Click += game1_click;
        }

        public override void UnloadContent()
        {
        }
        public override void Update(GameTime gameTime)
        {
            button1.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.Azure);

            spriteBatch.Begin();
            button1.Draw(spriteBatch);
            spriteBatch.End();
        }

        private void game1_click(object sender, EventArgs e)
        {
            StateManager.Instance.AddScreen(new GameplayState(_graphicsDevice));
        }
    }
}

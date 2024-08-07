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
        Button game1;
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

            game1 = new Button(buttontexture, spritefont) { buttonText = "textextext", position = new Vector2(300,250) };

            game1.Click += game1_click;
        }

        private void game1_click(object sender, EventArgs e)
        {
            StateManager.Instance.AddScreen(new GameplayState(_graphicsDevice));
        }

        public override void UnloadContent()
        {
        }
        public override void Update(GameTime gameTime)
        {
            game1.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.Azure);

            spriteBatch.Begin();
            game1.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}

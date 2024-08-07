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
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameStructure.GameStates
{
    public class GameplayState : State
    {
        SaveFile loadfile;
        List<Actor> actorss;
        public GameplayState(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void Initialize()
        {
            loadfile = XMLManager.Load<SaveFile>("Content/savedata.sav");
            actorss = loadfile.Actors.ToList();          
        }

        public override void LoadContent(ContentManager content)
        {
            foreach (Actor actor in actorss)
            {
                actor.loadContent(content);
            }
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Actor actor in actorss)
            {
                actor.Update(gameTime);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.MistyRose);

            spriteBatch.Begin();
            foreach (Actor actor in actorss)
            {
                actor.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

    }
}

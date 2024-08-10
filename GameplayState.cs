using GameStructure;
using GameStructure.Managers;
using GameStructure.Models;
using GameStructure.UI;
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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameStructure.GameStates
{
    public class GameplayState : State
    {
        public SaveFile saveFile;
        public List<Sprite> spritestoadd;
        public GameplayState(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void Initialize()
        {
            saveFile = XMLManager.Load<SaveFile>(Globals.PATH+"savedata1.sav");
            spritestoadd = saveFile.Actors;
        }

        public override void LoadContent(ContentManager content)
        {
            foreach (Sprite s in spritestoadd)
            {
                s.LoadContent(content);
            }
        }


        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Sprite s in spritestoadd)
            {
                s.Update(gameTime);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.MistyRose);

            spriteBatch.Begin();
            foreach (Sprite sprite in spritestoadd)
            {
                sprite.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        public void generateFile()
        {
            spritestoadd = new List<Sprite>()
            {
                new Sprite(){ name = "sprite1", pathtotexture = "phanpy", position = new Vector2(100,010)},
                new Sprite(){ name = "sprite2", pathtotexture = "phanpy", position = new Vector2(200,100)},
                new Player(){name = "sprite3", pathtotexture = "swablu", position = new Vector2(10,0)}

            };
            //players = new List<Player>()
            //{
            //    new Player(){name = "player", position = new Vector2(0,1), pathtotexture = "swablu"},
            //};
            saveFile = new SaveFile() { Actors = spritestoadd, Players = null};
            XMLManager.Save($"Content/savedata1.sav", saveFile);
        }
    }
}
//
//string xml = File.ReadAllText(Globals.PATH + "foo.xml");
//foo = Obj.Deserialize(xml, content);
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
using Vector3 = Microsoft.Xna.Framework.Vector3;

namespace GameStructure.GameStates
{
    public class GameplayState : State
    {
        public Camera camera;
        private Cylinder cylinder;
        public GameplayState(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void Initialize()
        {
            camera = new Camera();
            File.WriteAllText(Globals.PATH+"camera.xml", camera.Serialize());
        }

        public override void LoadContent(ContentManager content)
        {
            cylinder = new Cylinder();
            cylinder.LoadContent(content, "Models/PlaneBasic");
            cylinder.Position = new Vector3(0,0,0);
        }


        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            float rotation = 0.0f;
            Vector3 position = Vector3.Zero;
            camera.Update(rotation, position, _graphicsDevice.Viewport.AspectRatio);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.MistyRose);
            spriteBatch.Begin();

            cylinder.Draw(camera.ViewMatrix, camera.ProjectionMatrix);

            spriteBatch.End();
        }
    }
}
//
//string xml = File.ReadAllText(Globals.PATH + "foo.xml");
//foo = Obj.Deserialize(xml, content);
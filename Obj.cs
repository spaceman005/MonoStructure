using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace GameStructure.Models
{
    public class Obj
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture {  get; set; }
        public string Name { get; set; }

        public Obj(Texture2D texture, Vector2 pos)
        {
            Texture = texture;
            Position = pos;
        }

        public string Serialize()
        {
            return new XElement("Foo",new XElement("Position", new XElement("X", Position.X),new XElement("Y", Position.Y)), new XElement("Name", "phanpy")).ToString();
        }

        public static Obj Deserialize(string data, ContentManager content)
        {
            XElement xml = XElement.Parse(data);
            int x = int.Parse(xml.Element("Position").Element("X").Value);
            int y = int.Parse(xml.Element("Position").Element("Y").Value);

            Vector2 position = new Vector2(x, y);
            string name = xml.Element("Name").Value;
            Texture2D texture = content.Load<Texture2D>(name);
            return new Obj(texture, position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}

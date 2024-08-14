using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameStructure.Models
{
    public class RenderableGameObject : GameObject
    {
        [XmlIgnore]
        public Model Model { get; set; }
        public string pathToModel { get; set; }
        public float ForwardDirection { get; set; }
        public RenderableGameObject() : base()
        {
        }

        public virtual void LoadContent(ContentManager content)
        {
            Model = content.Load<Model>(pathToModel);
            Position = Vector3.Down;
            ForwardDirection = 0f;
        }
        public virtual void Draw(Matrix view, Matrix projection)
        {
            Matrix translateMatrix = Matrix.CreateTranslation(Position);
            Matrix worldMatrix = translateMatrix;

            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = worldMatrix;
                    effect.View = view;
                    effect.Projection = projection;

                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                }
                mesh.Draw();
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}

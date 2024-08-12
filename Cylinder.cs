using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStructure.Models
{
    public class Cylinder : GameObject
    {
        public bool Retrieved { get; set; }
        public Cylinder() : base()
        {
            Retrieved = false;
        }
        public void LoadContent(ContentManager content, string modelName)
        {
            Model = content.Load<Model>(modelName);
            Position = Vector3.Down;
        }

        public void Draw(Matrix view, Matrix projection)
        {
            Matrix translateMatrix = Matrix.CreateTranslation(Position);
            Matrix worldMatrix = translateMatrix;

            if (!Retrieved)
            {
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
        }
    }
}

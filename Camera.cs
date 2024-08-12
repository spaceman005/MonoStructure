using GameStructure.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameStructure
{
    public class Camera
    {
        public Vector3 AvatarHeadOffset { get; set; }
        public Vector3 TargetOffset { get; set; }
        public Matrix ViewMatrix { get; set; }
        public Matrix ProjectionMatrix { get; set; }

        public Camera()
        {
            AvatarHeadOffset = new Vector3(0, 7, -15);
            TargetOffset = new Vector3(0, 5, 0);
            ViewMatrix = Matrix.Identity;
            ProjectionMatrix = Matrix.Identity;
        }

        public void Update(float avatarYaw, Vector3 position, float aspectRatio)
        {
            Matrix rotationMatrix = Matrix.CreateRotationY(avatarYaw);

            Vector3 transformedheadOffset = Vector3.Transform(AvatarHeadOffset, rotationMatrix);
            Vector3 transformedReference = Vector3.Transform(TargetOffset, rotationMatrix);

            Vector3 cameraPosition = position + transformedheadOffset;
            Vector3 cameraTarget = position + transformedReference;

            //Calculate the camera's view and projection matrices based on current values.
            ViewMatrix = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(Globals.ViewAngle),
                aspectRatio, Globals.NearClip, Globals.FarClip);
        }

        public string Serialize() 
        {
            return new XElement("Camera", new XElement("ViewMatrix", ViewMatrix), 
                new XElement("ProjectionMatrix", ProjectionMatrix), 
                new XElement("AvatarHeadOffset",AvatarHeadOffset), 
                new XElement("TargetOffset", TargetOffset)).ToString();
        }

        public static Camera Deserialize(string data)
        {
            XElement xml = XElement.Parse(data);
            //Matrix view = xml.Element("");
            return new Camera();
        }

    }
}

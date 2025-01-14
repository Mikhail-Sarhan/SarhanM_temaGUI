using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTK3_StandardTemplate_WinForms.objects
{
    public class Camera
    {
        private int camPosX, camPosY, camPosZ;
        private int viewportWidth, viewportHeight;

        private const int CAM_POS_X = 100;
        private const int CAM_POS_Y = 100;
        private const int CAM_POS_Z = 50;

        public Camera(GLControl viewport)
        {
            Reset();

            viewportWidth = viewport.Width;
            viewportHeight = viewport.Height;
        }

        public void SetView()
        {
            // Calculate aspect ratio
            float aspectRatio = (float)viewportWidth / viewportHeight;

            // Create orthographic projection matrix
            float orthoSize = 100.0f; // Adjust this for zoom level
            Matrix4 orthographic = Matrix4.CreateOrthographic(orthoSize * aspectRatio, orthoSize, 0.1f, 256.0f);

            // Create look-at matrix
            Matrix4 lookat = Matrix4.LookAt(camPosX, camPosY, camPosZ, 0, 0, 0, 0, 1, 0);

            // Set Projection Matrix
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref orthographic);

            // Set Modelview Matrix
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(ref lookat);

            // Set Viewport
            GL.Viewport(0, 0, viewportWidth, viewportHeight);
        }

        public void Reset()
        {
            camPosX = CAM_POS_X;
            camPosY = CAM_POS_Y;
            camPosZ = CAM_POS_Z;
        }
    }
}

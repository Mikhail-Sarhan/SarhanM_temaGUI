// Add namespaces
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using OpenTK3_StandardTemplate_WinForms.helpers;
using OpenTK3_StandardTemplate_WinForms.objects;

namespace OpenTK3_StandardTemplate_WinForms
{
    public partial class MainForm : Form
    {
        private Axes mainAxis;
        private Camera cam;
        private Scene scene;

        private Point mousePosition;

        private Timer animationTimer;
        private float rotationAngle = 0.0f; 
        private int textureId;
        private bool isCubeDrawn = false;
        private bool isTextureLoaded = false;
        private bool isLightEnabled = false;
        private float[] lightAmbient = { 3f, 3f, 3f, 1.0f }; 
        private float alpha = 1.0f; 

        public MainForm()
        {
            InitializeComponent();
            scene = new Scene();

            scene.GetViewport().Load += new EventHandler(this.mainViewport_Load);
            scene.GetViewport().Paint += new PaintEventHandler(this.mainViewport_Paint);
            scene.GetViewport().MouseMove += new MouseEventHandler(this.mainViewport_MouseMove);
            this.Controls.Add(scene.GetViewport());

            animationTimer = new Timer();
            animationTimer.Interval = 16; 
            animationTimer.Tick += (s, e) => {
                rotationAngle += 1.0f; 
                if (rotationAngle >= 360.0f) rotationAngle = 0.0f;
                scene.Invalidate(); 
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Randomizer.Init();
            cam = new Camera(scene.GetViewport());
            mainAxis = new Axes(showAxes.Checked);
        }

        private void showAxes_CheckedChanged(object sender, EventArgs e)
        {
            mainAxis.SetVisibility(showAxes.Checked);
            scene.Invalidate();
        }

        private void changeBackground_Click(object sender, EventArgs e)
        {
            GL.ClearColor(Randomizer.GetRandomColor());
            scene.Invalidate();
        }

        private void resetScene_Click(object sender, EventArgs e)
        {
            showAxes.Checked = true;
            mainAxis.SetVisibility(showAxes.Checked);
            scene.Reset();
            cam.Reset();
            isCubeDrawn = false;
            isTextureLoaded = false;
            isLightEnabled = false;
            animationTimer.Stop();
            rotationAngle = 0.0f;
            toggleLightButton.Checked = false;
            toggleRotationButton.Checked = false;
            labelAlphaValue.Text = "Alpha Intensity";
            alpha = 1;
            trackBarAlpha.Value = trackBarAlpha.Maximum;
            trackBar1.Value = 0;
            scene.Invalidate();
        }

        private void mainViewport_Load(object sender, EventArgs e)
        {
            scene.Reset();
        }

        private void mainViewport_MouseMove(object sender, MouseEventArgs e)
        {
            mousePosition = new Point(e.X, e.Y);
            scene.Invalidate();
        }

        private void mainViewport_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            cam.SetView();

            if (isLightEnabled)
            {
                float[] lightPosition = { 16f, 20f, 16f, 1.0f };
                float[] lightDiffuse = { 1.0f, 1.0f, 1.0f, 1.0f };
                float[] lightSpecular = { 1.0f, 1.0f, 1.0f, 1.0f };
                float[] materialDiffuseWithAlpha = { 0.8f, 0.8f, 0.8f, alpha }; 

                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                GL.Light(LightName.Light0, LightParameter.Position, lightPosition);
                GL.Light(LightName.Light0, LightParameter.Diffuse, lightDiffuse);
                GL.Light(LightName.Light0, LightParameter.Specular, lightSpecular);
                GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, materialDiffuseWithAlpha);
                GL.Material(MaterialFace.Front, MaterialParameter.Specular, lightSpecular);
                GL.Material(MaterialFace.Front, MaterialParameter.Shininess, 50.0f);
            }
            else
            {
                GL.Disable(EnableCap.Lighting);
            }

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Color4(1.0f, 1.0f, 1.0f, alpha); 
            GL.Disable(EnableCap.Blend);


            mainAxis.Draw();

            if (isCubeDrawn)
            {
                
                GL.PushMatrix();
                GL.Rotate(rotationAngle, 0.0f, 1.0f, 0.0f);

                GL.Enable(EnableCap.Blend);
                GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);


                if (isTextureLoaded)
                {

                    float[] materialSpecular = { 1.0f, 1.0f, 1.0f, 1.0f }; 
                    float shininess = 50.0f; 

                    GL.Material(MaterialFace.Front, MaterialParameter.Specular, materialSpecular);
                    GL.Material(MaterialFace.Front, MaterialParameter.Shininess, shininess);

                    GL.Color4(1.0f, 1.0f, 1.0f, alpha);
                    DrawCube(textureId);
                    GL.Disable(EnableCap.Blend);

                }
                else
                {
                    GL.Color4(0.2f, 0.2f, 0.2f, alpha); 
                    DrawCube(0);
                    GL.Disable(EnableCap.Blend); 

                }

                GL.PopMatrix();
            }

            scene.GetViewport().SwapBuffers();
        }

        private int LoadTexture(string filePath)
        {
            Bitmap bitmap = new Bitmap(filePath);
            int texture;
            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bitmap.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            return texture;
        }


        private void DrawCube(int textureId)
        {
            GL.Scale(15, 15, 15);
            GL.BindTexture(TextureTarget.Texture2D, textureId);

            GL.Begin(PrimitiveType.Quads);

            // Top face (Normal pointing up)
            GL.Normal3(0.0f, 1.0f, 0.0f);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(-0.5f, 0.5f, -0.5f); // Top-left
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0.5f, 0.5f, -0.5f);  // Top-right
            GL.TexCoord2(1.0f, 0.5f); GL.Vertex3(0.5f, 0.5f, 0.5f);   // Bottom-right
            GL.TexCoord2(0.0f, 0.5f); GL.Vertex3(-0.5f, 0.5f, 0.5f);  // Bottom-left

            // Bottom face (Normal pointing down)
            GL.Normal3(0.0f, -1.0f, 0.0f);
            GL.TexCoord2(0.0f, 0.5f); GL.Vertex3(-0.5f, -0.5f, -0.5f); // Top-left
            GL.TexCoord2(1.0f, 0.5f); GL.Vertex3(0.5f, -0.5f, -0.5f);  // Top-right
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0.5f, -0.5f, 0.5f);   // Bottom-right
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-0.5f, -0.5f, 0.5f);  // Bottom-left

            // Front face (Normal pointing forward)
            GL.Normal3(0.0f, 0.0f, 1.0f);
            GL.TexCoord2(0.0f, 0.5f); GL.Vertex3(-0.5f, -0.5f, 0.5f); // Bottom-left
            GL.TexCoord2(1.0f, 0.5f); GL.Vertex3(0.5f, -0.5f, 0.5f);  // Bottom-right
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0.5f, 0.5f, 0.5f);   // Top-right
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-0.5f, 0.5f, 0.5f);  // Top-left

            // Back face (Normal pointing backward)
            GL.Normal3(0.0f, 0.0f, -1.0f);
            GL.TexCoord2(0.0f, 0.5f); GL.Vertex3(-0.5f, -0.5f, -0.5f); // Bottom-left
            GL.TexCoord2(1.0f, 0.5f); GL.Vertex3(0.5f, -0.5f, -0.5f);  // Bottom-right
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0.5f, 0.5f, -0.5f);   // Top-right
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-0.5f, 0.5f, -0.5f);  // Top-left

            // Left face (Normal pointing left)
            GL.Normal3(-1.0f, 0.0f, 0.0f);
            GL.TexCoord2(0.0f, 0.5f); GL.Vertex3(-0.5f, -0.5f, -0.5f); // Bottom-left
            GL.TexCoord2(1.0f, 0.5f); GL.Vertex3(-0.5f, -0.5f, 0.5f);  // Bottom-right
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(-0.5f, 0.5f, 0.5f);   // Top-right
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(-0.5f, 0.5f, -0.5f);  // Top-left

            // Right face (Normal pointing right)
            GL.Normal3(1.0f, 0.0f, 0.0f);
            GL.TexCoord2(0.0f, 0.5f); GL.Vertex3(0.5f, -0.5f, -0.5f); // Bottom-left
            GL.TexCoord2(1.0f, 0.5f); GL.Vertex3(0.5f, -0.5f, 0.5f);  // Bottom-right
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0.5f, 0.5f, 0.5f);   // Top-right
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0.5f, 0.5f, -0.5f);  // Top-left

            GL.End();
        }



        private void toggleRotation_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleRotationButton.Checked)
            {
                animationTimer.Start();
            }
            else
            {
                animationTimer.Stop();
            }
        }

        private void loadTex_Click(object sender, EventArgs e)
        {
            if (isCubeDrawn)
            {
                textureId = LoadTexture("atlas-01.png"); 
                isTextureLoaded = true;
                scene.Invalidate();
            }
            else
            {
                MessageBox.Show("Draw the cube first!");
            }
        }

        private void drawCub_Click(object sender, EventArgs e)
        {
            isCubeDrawn = true;
            scene.Invalidate();

        }

        private void toggleLightButton_CheckedChanged(object sender, EventArgs e)
        {
            isLightEnabled = toggleLightButton.Checked;
            scene.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
          
            float intensity = trackBar1.Value / (float)trackBar1.Maximum; 
            lightAmbient[0] = intensity * 4;
            lightAmbient[1] = intensity * 4;
            lightAmbient[2] = intensity * 4;

           
            GL.Light(LightName.Light0, LightParameter.Ambient, lightAmbient);

            
            scene.Invalidate();
        }

        private void trackBarAlpha_Scroll(object sender, EventArgs e)
        {
            
            alpha = trackBarAlpha.Value / 10f;

           
            labelAlphaValue.Text = $"Alpha: {trackBarAlpha.Value*10}%";

          
            scene.Invalidate();
        }

    }
}

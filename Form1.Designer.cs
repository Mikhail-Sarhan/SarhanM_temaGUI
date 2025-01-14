
namespace OpenTK3_StandardTemplate_WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.showAxes = new System.Windows.Forms.CheckBox();
            this.changeBackground = new System.Windows.Forms.Button();
            this.lblOx = new System.Windows.Forms.Label();
            this.lblOy = new System.Windows.Forms.Label();
            this.lblOz = new System.Windows.Forms.Label();
            this.resetScene = new System.Windows.Forms.Button();
            this.drawCub = new System.Windows.Forms.Button();
            this.loadTex = new System.Windows.Forms.Button();
            this.toggleRotationButton = new System.Windows.Forms.CheckBox();
            this.toggleLightButton = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarAlpha = new System.Windows.Forms.TrackBar();
            this.labelAlphaValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlpha)).BeginInit();
            this.SuspendLayout();
            // 
            // showAxes
            // 
            this.showAxes.AutoSize = true;
            this.showAxes.Checked = true;
            this.showAxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showAxes.Location = new System.Drawing.Point(976, 16);
            this.showAxes.Margin = new System.Windows.Forms.Padding(4);
            this.showAxes.Name = "showAxes";
            this.showAxes.Size = new System.Drawing.Size(97, 21);
            this.showAxes.TabIndex = 0;
            this.showAxes.Text = "Show Axes";
            this.showAxes.UseVisualStyleBackColor = true;
            this.showAxes.CheckedChanged += new System.EventHandler(this.showAxes_CheckedChanged);
            // 
            // changeBackground
            // 
            this.changeBackground.Location = new System.Drawing.Point(976, 100);
            this.changeBackground.Margin = new System.Windows.Forms.Padding(4);
            this.changeBackground.Name = "changeBackground";
            this.changeBackground.Size = new System.Drawing.Size(233, 39);
            this.changeBackground.TabIndex = 1;
            this.changeBackground.Text = "Change background color";
            this.changeBackground.UseVisualStyleBackColor = true;
            this.changeBackground.Click += new System.EventHandler(this.changeBackground_Click);
            // 
            // lblOx
            // 
            this.lblOx.BackColor = System.Drawing.Color.Red;
            this.lblOx.Location = new System.Drawing.Point(1002, 43);
            this.lblOx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOx.Name = "lblOx";
            this.lblOx.Size = new System.Drawing.Size(47, 25);
            this.lblOx.TabIndex = 2;
            this.lblOx.Text = "Ox";
            this.lblOx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOy
            // 
            this.lblOy.BackColor = System.Drawing.Color.Green;
            this.lblOy.Location = new System.Drawing.Point(1056, 43);
            this.lblOy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOy.Name = "lblOy";
            this.lblOy.Size = new System.Drawing.Size(47, 25);
            this.lblOy.TabIndex = 3;
            this.lblOy.Text = "Oy";
            this.lblOy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOz
            // 
            this.lblOz.BackColor = System.Drawing.Color.Blue;
            this.lblOz.Location = new System.Drawing.Point(1110, 43);
            this.lblOz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOz.Name = "lblOz";
            this.lblOz.Size = new System.Drawing.Size(47, 25);
            this.lblOz.TabIndex = 4;
            this.lblOz.Text = "Oz";
            this.lblOz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetScene
            // 
            this.resetScene.Location = new System.Drawing.Point(976, 147);
            this.resetScene.Margin = new System.Windows.Forms.Padding(4);
            this.resetScene.Name = "resetScene";
            this.resetScene.Size = new System.Drawing.Size(233, 39);
            this.resetScene.TabIndex = 5;
            this.resetScene.Text = "Reset scene";
            this.resetScene.UseVisualStyleBackColor = true;
            this.resetScene.Click += new System.EventHandler(this.resetScene_Click);
            // 
            // drawCub
            // 
            this.drawCub.BackColor = System.Drawing.SystemColors.Highlight;
            this.drawCub.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawCub.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.drawCub.Location = new System.Drawing.Point(976, 239);
            this.drawCub.Name = "drawCub";
            this.drawCub.Size = new System.Drawing.Size(233, 38);
            this.drawCub.TabIndex = 8;
            this.drawCub.Text = "Draw Cube";
            this.drawCub.UseVisualStyleBackColor = false;
            this.drawCub.Click += new System.EventHandler(this.drawCub_Click);
            // 
            // loadTex
            // 
            this.loadTex.BackColor = System.Drawing.SystemColors.Highlight;
            this.loadTex.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadTex.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.loadTex.Location = new System.Drawing.Point(976, 283);
            this.loadTex.Name = "loadTex";
            this.loadTex.Size = new System.Drawing.Size(233, 38);
            this.loadTex.TabIndex = 9;
            this.loadTex.Text = "Load Texture";
            this.loadTex.UseVisualStyleBackColor = false;
            this.loadTex.Click += new System.EventHandler(this.loadTex_Click);
            // 
            // toggleRotationButton
            // 
            this.toggleRotationButton.AutoSize = true;
            this.toggleRotationButton.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleRotationButton.Location = new System.Drawing.Point(976, 328);
            this.toggleRotationButton.Margin = new System.Windows.Forms.Padding(4);
            this.toggleRotationButton.Name = "toggleRotationButton";
            this.toggleRotationButton.Size = new System.Drawing.Size(196, 25);
            this.toggleRotationButton.TabIndex = 10;
            this.toggleRotationButton.Text = "Enable object rotation";
            this.toggleRotationButton.UseVisualStyleBackColor = true;
            this.toggleRotationButton.CheckedChanged += new System.EventHandler(this.toggleRotation_CheckedChanged);
            // 
            // toggleLightButton
            // 
            this.toggleLightButton.AutoSize = true;
            this.toggleLightButton.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleLightButton.Location = new System.Drawing.Point(976, 361);
            this.toggleLightButton.Margin = new System.Windows.Forms.Padding(4);
            this.toggleLightButton.Name = "toggleLightButton";
            this.toggleLightButton.Size = new System.Drawing.Size(131, 25);
            this.toggleLightButton.TabIndex = 11;
            this.toggleLightButton.Text = "Enable Lights";
            this.toggleLightButton.UseVisualStyleBackColor = true;
            this.toggleLightButton.CheckedChanged += new System.EventHandler(this.toggleLightButton_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(969, 438);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(240, 56);
            this.trackBar1.TabIndex = 12;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(978, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Light Intensity";
            // 
            // trackBarAlpha
            // 
            this.trackBarAlpha.Location = new System.Drawing.Point(976, 521);
            this.trackBarAlpha.Name = "trackBarAlpha";
            this.trackBarAlpha.Size = new System.Drawing.Size(240, 56);
            this.trackBarAlpha.TabIndex = 14;
            this.trackBarAlpha.Value = 10;
            this.trackBarAlpha.Scroll += new System.EventHandler(this.trackBarAlpha_Scroll);
            // 
            // labelAlphaValue
            // 
            this.labelAlphaValue.AutoSize = true;
            this.labelAlphaValue.Location = new System.Drawing.Point(978, 497);
            this.labelAlphaValue.Name = "labelAlphaValue";
            this.labelAlphaValue.Size = new System.Drawing.Size(98, 17);
            this.labelAlphaValue.TabIndex = 15;
            this.labelAlphaValue.Text = "Alpha Intensity";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 768);
            this.Controls.Add(this.labelAlphaValue);
            this.Controls.Add(this.trackBarAlpha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.toggleLightButton);
            this.Controls.Add(this.toggleRotationButton);
            this.Controls.Add(this.loadTex);
            this.Controls.Add(this.drawCub);
            this.Controls.Add(this.resetScene);
            this.Controls.Add(this.lblOz);
            this.Controls.Add(this.lblOy);
            this.Controls.Add(this.lblOx);
            this.Controls.Add(this.changeBackground);
            this.Controls.Add(this.showAxes);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "OpenTK 3";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAlpha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox showAxes;
        private System.Windows.Forms.Button changeBackground;
        private System.Windows.Forms.Label lblOx;
        private System.Windows.Forms.Label lblOy;
        private System.Windows.Forms.Label lblOz;
        private System.Windows.Forms.Button resetScene;
        private System.Windows.Forms.Button drawCub;
        private System.Windows.Forms.Button loadTex;
        private System.Windows.Forms.CheckBox toggleRotationButton;
        private System.Windows.Forms.CheckBox toggleLightButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarAlpha;
        private System.Windows.Forms.Label labelAlphaValue;
    }
}


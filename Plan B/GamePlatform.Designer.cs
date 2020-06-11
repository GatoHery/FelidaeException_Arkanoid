using System.ComponentModel;
using System.Windows.Forms;

namespace Plan_B
{
    partial class GamePlatform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(GamePlatform));
            this.picPaddle = new System.Windows.Forms.PictureBox();
            this.GamePlatformTimer_Tick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize) (this.picPaddle)).BeginInit();
            this.SuspendLayout();
            // 
            // picPaddle
            // 
            this.picPaddle.BackColor = System.Drawing.Color.Transparent;
            this.picPaddle.Location = new System.Drawing.Point(315, 352);
            this.picPaddle.Margin = new System.Windows.Forms.Padding(1);
            this.picPaddle.Name = "picPaddle";
            this.picPaddle.Size = new System.Drawing.Size(99, 31);
            this.picPaddle.TabIndex = 0;
            this.picPaddle.TabStop = false;
            // 
            // GamePlatformTimer_Tick
            // 
            this.GamePlatformTimer_Tick.Tick += new System.EventHandler(this.GamePlatformTimer_Tick_Tick);
            // 
            // GamePlatform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(820, 393);
            this.Controls.Add(this.picPaddle);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "GamePlatform";
            this.Text = "Felidae Arkanoid Exception";
            this.Load += new System.EventHandler(this.GamePlatform_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GamePlatform_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GamePlatform_MouseMove);
            ((System.ComponentModel.ISupportInitialize) (this.picPaddle)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Timer GamePlatformTimer_Tick;
        private System.Windows.Forms.PictureBox picPaddle;

        #endregion
    }
}
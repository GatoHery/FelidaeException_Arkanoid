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
            this.picPaddle = new System.Windows.Forms.PictureBox();
            this.GamePlatformTimer_Tick = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.picPaddle)).BeginInit();
            this.SuspendLayout();
            // 
            // picPaddle
            // 
            this.picPaddle.Location = new System.Drawing.Point(212, 342);
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Minecraft Evenings", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(719, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Minecraft Evenings", 12F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(649, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Score: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GamePlatform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(820, 393);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picPaddle);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "GamePlatform";
            this.Text = "Felidae Arkanoid Exception";
            this.Load += new System.EventHandler(this.GamePlatform_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GamePlatform_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GamePlatform_MouseMove);
            ((System.ComponentModel.ISupportInitialize) (this.picPaddle)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox picPaddle;
        private System.Windows.Forms.Timer GamePlatformTimer_Tick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
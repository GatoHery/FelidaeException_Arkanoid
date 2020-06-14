using System.ComponentModel;

namespace Plan_B
{
    partial class Menu
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnTop10 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Minecraft Evenings", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(795, 104);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(1019, 130);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play!";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnTop10
            // 
            this.btnTop10.Font = new System.Drawing.Font("Minecraft Evenings", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTop10.Location = new System.Drawing.Point(795, 348);
            this.btnTop10.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnTop10.Name = "btnTop10";
            this.btnTop10.Size = new System.Drawing.Size(1019, 130);
            this.btnTop10.TabIndex = 4;
            this.btnTop10.Text = "Top 10";
            this.btnTop10.UseVisualStyleBackColor = true;
            this.btnTop10.Click += new System.EventHandler(this.btnTop10_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Minecraft Evenings", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(795, 597);
            this.btnExit.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(1019, 130);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTop10);
            this.Controls.Add(this.btnPlay);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(2658, 1157);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnTop10;
        private System.Windows.Forms.Button btnExit;
    }
}
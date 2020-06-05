using System;
using System.Drawing;
using System.Windows.Forms;

namespace Plan_B
{
    public partial class Game : Form
    {
        int playerSped;
        int ballx;
        int bally;
        int score;

        bool l;
        bool r;
        bool go;
        
        Random ran  = new Random();
        public Game()
        {
            InitializeComponent();
            Hearts1.Image = imageListHearts.Images[0]; 
            Hearts2.Image = imageListHearts.Images[0];
            Hearts3.Image = imageListHearts.Images[0];
            setting();
        }
        private void setting()
        {
            go = false;
            playerSped = 30;
            ballx = 20;
            bally = 20;
            score = 0;
            label5.Text = "Score: " + score;
            gameTimer.Start();
            
            
        }
        private void gameOver()
        {
            go = true;
            gameTimer.Stop();
            label5.Text = score.ToString();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            int i = 0;
            label5.Text = score.ToString();
            
            if(l == true && picPlayer.Left > 0){
                picPlayer.Left -= playerSped;
            } 
            if(r == true && picPlayer.Right < 880){
                picPlayer.Left += playerSped;
            }

            pictureBox11.Left += ballx;
            pictureBox11.Top += bally;

            if (pictureBox11.Left > 0 || pictureBox11.Left < 950)
            {
                ballx = -ballx;
            }

            if (pictureBox11.Top < 0)
            {
                bally = -bally;
            }

            if (pictureBox11.Bounds.IntersectsWith(picPlayer.Bounds))
            {
                bally = ran.Next(5, 12) * -1;

                if (ballx < 0)
                {
                    ballx = ran.Next(5, 12) * -1;
                }
                else
                {
                    ballx = ran.Next(5, 12);
                } 
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string) x.Tag == "pieces")
                {
                    if (pictureBox11.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;
                        bally = -bally;
                        
                        this.Controls.Remove(x);
                    }
                }
            }

            if (score == 30)
            {
                gameOver();
                MessageBox.Show("Congrats! You win!!");
                this.Close();
            }
            
            if (pictureBox11.Top > 773)
            {
                Hearts1.Image = imageListHearts.Images[1];
                i++;
            }
            else if(pictureBox11.Top > 773)
            {
                Hearts2.Image = imageListHearts.Images[1];
                i++;
            }
            else if(pictureBox11.Top > 773)
            {
                Hearts3.Image = imageListHearts.Images[1];
                i++;
            }

            if (i == 3)
            {
                gameOver();
                MessageBox.Show("You lose");
                this.Close();
            }
        }

        private void keyd(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                l = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                r = true;
            }
        }
        private void keyu(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                l = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                r = false;
            }
        }
    }
}


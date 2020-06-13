using System;
using System.Drawing;
using System.Windows.Forms;

namespace Plan_B
{
    public partial class GamePlatform : Form
        {
            private CustomPictureBox[,] cpb;
            private CustomPictureBox2[,] cpb2;
            private PictureBox ball;
            private Label sco;
            private PictureBox hearts;
            
            //The function initializa the height and the width from the game
            public GamePlatform()
            {
                InitializeComponent();
                Height = ClientSize.Height;
                Width = ClientSize.Width;
                WindowState = FormWindowState.Maximized;
            }
            //This function permits the load of the game in the designer platform
            private void GamePlatform_Load(object sender, EventArgs e)
            {
                try
                {
                    //Setting attributes for PictureBox player
                    picPaddle.BackgroundImage = Image.FromFile("../../Textures/Player.jpg");
                    picPaddle.BackgroundImageLayout = ImageLayout.Stretch;
    
                    picPaddle.Top = Height - picPaddle.Height - 80;
                    picPaddle.Left = (Width / 2) - (picPaddle.Width / 2);
                    
                    //Setting attributes for PictureBox ball
                    ball = new PictureBox();
                    ball.Width = ball.Height = 20;
                    ball.BackgroundImage = Image.FromFile("../../Textures/Ball.png");
                    ball.BackgroundImageLayout = ImageLayout.Stretch;
    
                    ball.Top = picPaddle.Top - ball.Height;
                    ball.Left = picPaddle.Left + (picPaddle.Width / 2) - (ball.Width / 2);
                    
                    //Setting attributes for Label sco
                    sco = new Label();
                    sco.Top = Height - sco.Height - 720;
                    sco.Left = (Width) - (sco.Width);
                    sco.BackColor = Color.White;
                    
                    Controls.Add(ball);
                    Controls.Add(sco);
                    
                    LoadTiles();
                    LoadHearts();
                    GamePlatformTimer_Tick.Start();
    
                }
                catch (Exception exceptionGame)
                {
                    MessageBox.Show("An error has ocurred");
                }
            }
    
            private void LoadHearts()
            {
                try
                {
                    int ax = 3;
                    int ay = 1;
    
                    int PlatformH = (int) (Height * 0.1) / ay;
                    int PlatformW = (Width - ax)/ ax - 350;
                    
                    cpb2 = new CustomPictureBox2[ay, ax];
    
                    for (int a = 0; a < ay; a++)
                    {
                        for (int b = 0; b < ax; b++)
                        {
                            cpb2[a, b] = new CustomPictureBox2();
                            
                            //Position from Height, Position from Width
                            cpb2[a, b].Height = PlatformH;
                            cpb2[a, b].Width = PlatformW;
    
    
                            //Position from Left, Position from Top
                            cpb2[a, b].Left = b * PlatformW - 50;
                            cpb2[a, b].Top = a * PlatformH + 20;
    
                            //If the value from i = 0, then put on the route from the brick pictureBox
                            cpb2[a, b].BackgroundImage = Image.FromFile("../../Textures/Heart.png");
                            cpb2[a, b].BackgroundImageLayout = ImageLayout.Stretch;
    
                            cpb2[a, b].Tag = "tileTag";
    
                            Controls.Add(cpb2[a, b]);  
                        }
                    }
                }
                catch (Exception exceptionGameOver)
                {
                    MessageBox.Show("Game over");
                }
            }
            //This function, permits fill the platform with bricks, and pick the photos from code
    
            private void LoadTiles()
            {
                try
                {
                    int xAxis = 10;
                    int yAxis = 5;
                  
                    int PlatFormHeight = (int)(Height * 0.3) / yAxis;
                    int PlatFormWidth = (Width - (xAxis - 5)) / xAxis;
    
                    cpb = new CustomPictureBox[yAxis, xAxis];
    
                    for (int i = 0; i < yAxis; i++)
                    {
                        for (int j = 0; j < xAxis; j++)
                        {
                            cpb[i, j] = new CustomPictureBox();
    
                            if (i == 0)
                                cpb[i, j].Hits = 2;
                            else
                                cpb[i, j].Hits = 1;
    
    
                            //Position from Height, Position from Width
                            cpb[i, j].Height = PlatFormHeight;
                            cpb[i, j].Width = PlatFormWidth;
    
    
                            //Position from Left, Position from Top
    
                            cpb[i, j].Left = j * PlatFormWidth;
                            cpb[i, j].Top = i * PlatFormHeight + sco.Width;
    
                            //If the value from i = 0, then put on the route from the brick pictureBox
                            cpb[i, j].BackgroundImage = Image.FromFile("../../Textures/" + GRN() + ".png");
                            cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;
    
                            cpb[i, j].Tag = "tileTag";
    
                            Controls.Add(cpb[i, j]);
                            
                        }
                    }
    
                }
                catch (Exception exceptionGameOver)
                {
                    MessageBox.Show("The game has end");
                }
                
            }
    
            //Random functions that permits show bricks from multiple colors randomly
            private int GRN()
            {
                return new Random().Next(1, 8);
            }
            
            //Permits the use of touchpad as the movement of the platform ball and paddle
            private void GamePlatform_MouseMove(object sender, MouseEventArgs e)
            {
                try
                {
                    if (!GameData.GameStarted)
                    {
                        if (e.X < (Width - picPaddle.Width))
                        {
                            picPaddle.Left = e.X;
                            ball.Left = picPaddle.Left + (picPaddle.Width / 2) - (ball.Width / 2);
                        }
                    }
                    else
                    {
                        if (e.X < (Width - picPaddle.Width))
                            picPaddle.Left = e.X;
                    }
                    
    
                }
                catch (Exception exceptionMouseMovement)
                {
                    MessageBox.Show("An error has ocurred in your mouse");
                }
                
                
            }
    
            //Function work for player still play until it lose
            private void GamePlatformTimer_Tick_Tick(object sender, EventArgs e)
            {
                sco.Text = "Score: " + ScoreIncrease.score;
                try
                {
                    if (!GameData.GameStarted)
                    {
                        return;
                    }
    
                    ball.Left += GameData.dirX;
                    ball.Top += GameData.dirY;
    
                    rebotarPelota();
    
                }
                catch (Exception exceptionGameTimer)
                {
                    MessageBox.Show("An error has ocurred in the Game Timer");
                }
               
            }
            
            
            //The KeyDown function is used to allow the start of the game 
            private void GamePlatform_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Space)
                    GameData.GameStarted = true; 
            }
           
            //Function provides ball bounds inside platform
            private void rebotarPelota()
            {
                try
                {
                    if(ball.Bottom > Height)
                    {
                        Application.Exit();
                        GamePlatformTimer_Tick.Stop();
                        MessageBox.Show("Game over");
                        this.Close();
                    }
    
                    if (ball.Left < 0 || ball.Right > Width)
                    {
                        GameData.dirX = -GameData.dirX;
                        return;
                    }
    
                    if (ball.Bounds.IntersectsWith(picPaddle.Bounds))
                    {
                        GameData.dirY = -GameData.dirY;
                    }
    
                    for (int i = 4; i >= 0; i--)
                    {
    
                        for (int j = 0; j < 10; j++)
                        {
                            if (cpb[i, j] != null && ball.Bounds.IntersectsWith(cpb[i,j].Bounds))
                            {
                                cpb[i, j].Hits--;
                                
                                if (cpb[i,j].Hits == 0)
                                {
                                    //Calling the function to increase the score
                                    ScoreIncrease.score++;
                                    Controls.Remove(cpb[i,j]);
                                    cpb[i, j] = null;
                                }
                                GameData.dirY = -GameData.dirY;
                            
                                return;
                            }
                        }
                    }
                }
                catch (Exception exceptionBallBounds)
                {
                    MessageBox.Show("An error has ocurred with the ball bounds");
                }
            }
        }
}
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Plan_B
{
    public partial class GamePlatform : Form
        {
            private CustomPictureBox[,] cpb;
            private PictureBox ball;
            private Label score;
            private PictureBox[] hearts;
            private string PlayerName;
            private Panel scorePanel;
            
            //The function initializa the height and the width from the game
            public GamePlatform(string Player)
            {
                InitializeComponent();
                Height = ClientSize.Height;
                Width = ClientSize.Width;
                WindowState = FormWindowState.Maximized;
                PlayerName = Player;
            }
            
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams handleParam = base.CreateParams;
                    handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                    return handleParam;
                }
            }

            //This function permits the load of the game in the designer platform
            private void GamePlatform_Load(object sender, EventArgs e)
            {
                try
                {

                    GameData.initializeGame();
                    ScorePanel();
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
                    
                    Controls.Add(ball);

                    LoadTiles();
                    GamePlatformTimer_Tick.Start();
    
                }
                catch (Exception exceptionGame)
                {
                    MessageBox.Show("An error has ocurred");
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
    
                            if (i == 2)
                                cpb[i, j].Hits = 2;
                            else
                                cpb[i, j].Hits = 1;
                            
                            //Setting the size
                            cpb[i, j].Height = PlatFormHeight;
                            cpb[i, j].Width = PlatFormWidth;
                            
                            //Position from Left, Position from Top
                            cpb[i, j].Left = j * PlatFormWidth;
                            cpb[i, j].Top = i * PlatFormHeight + scorePanel.Height + 1;
                            
                            int imageBack = 0;

                            if (i % 2 == 0 && j % 2 == 0)
                                imageBack = 3;
                            else if (i % 2 == 0 && j % 2 != 0)
                                imageBack = 4;
                            else if (i % 2 != 0 && j % 2 == 0)
                                imageBack = 4;
                            else
                                imageBack = 3;

                            //Generar un numero aleatorio para que sean blindados...
                            //Tener cuidado con los numero aleatorios, necesitan seed que se tome con el tiempo
                            if (i == 2)
                            {
                                cpb[i, j].BackgroundImage = Image.FromFile("../../Textures/Tileblinded.png");
                                cpb[i, j].Tag = "blinded";
                            }
                            else
                            {
                                cpb[i, j].BackgroundImage = Image.FromFile("../../Textures/" + imageBack + ".png");
                                cpb[i, j].Tag = "tileTag";
                            }

                            cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch;

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
                score.Text = "Score: " + GameData.score;
                try
                {
                    if (!GameData.GameStarted)
                    {
                        return;
                    }
    
                    ball.Left += GameData.dirX;
                    ball.Top += GameData.dirY;
    
                    bounceBall();
    
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
            private void bounceBall()
            {
                try
                {
                    if(ball.Bottom > Height)
                    {
                        GameData.lifes--;
                        
                        repositionElements();
                        updateItems();

                        GameData.GameStarted = false;
                        GamePlatformTimer_Tick.Start();
                        
                        if (GameData.lifes == 0)
                        {
                            GamePlatformTimer_Tick.Stop();
                            MessageBox.Show("Game over");
                            ConnectionDB.ExecuteNonQuery($"UPDATE PLAYER set score = {GameData.score} " +
                                                   $"where name = '{PlayerName}'");
                            ConnectionDB.ExecuteNonQuery($"INSERT INTO SCOREBOARD(name,score,dategame) VALUES ('{PlayerName}',{GameData.score},NOW())");

                        this.Close(); 
                        }
                    }
    
                    if (ball.Left < 0 || ball.Right > Width)
                    {
                        GameData.dirX = -GameData.dirX;
                        return;
                    }

                    if (ball.Top < 0)
                    {
                        GameData.dirY = -GameData.dirY;
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
                                    GameData.score = GameData.score + 150;
                                    Controls.Remove(cpb[i,j]);
                                    cpb[i, j] = null;
                                }
                                else if (cpb[i, j].Tag.Equals("blinded"))
                                    cpb[i, j].BackgroundImage = Image.FromFile("../../Textures/Tileblindedbroken.png");
                                
                                GameData.dirY = -GameData.dirY;

                                score.Text = "Score: " + GameData.score;
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

            //Setting attributes for PanelScore
            private void ScorePanel(){
                //Instantiate panel
                scorePanel = new Panel();
                
                //Set panel elements
                scorePanel.Width = Width;
                scorePanel.Height = (int)(Height * 0.09);

                scorePanel.Top = scorePanel.Left = 0;

                scorePanel.BackColor = Color.Transparent;
            
                hearts = new PictureBox[GameData.lifes];

                for (int i = 0; i < GameData.lifes; i++)
                {
                    // Instantiation of PictureBox
                    hearts[i] = new PictureBox();
                    hearts[i].Height = hearts[i].Width = scorePanel.Height;
                    
                    hearts[i].BackgroundImage = Image.FromFile("../../Textures/Heart.png");
                    hearts[i].BackgroundImageLayout = ImageLayout.Stretch;

                    hearts[i].Top = 0;

                    if (i == 0)
                        hearts[i].Left = 20;
                    else
                    {
                        hearts[i].Left = hearts[i - 1].Right + 5;
                    }
                }
                //Instantiate label
                score = new Label();
                
                //Set label elements
                score.ForeColor = Color.White;

                score.Text = GameData.score.ToString();
                
                score.Font = new Font("Minecraft Evenings", 14F);
                
                score.TextAlign = ContentAlignment.MiddleCenter;

                score.Left = Width - 200;
                score.Height = scorePanel.Height;
                
                scorePanel.Controls.Add(score);

                foreach (var h in hearts)
                {
                    scorePanel.Controls.Add(h);
                }
                
                Controls.Add(scorePanel);
            }

            //Relocate ball and picPaddle
            private void repositionElements()
            {
                picPaddle.Left = (Width / 2) - (picPaddle.Width / 2);
                ball.Top = picPaddle.Top - ball.Height;
                ball.Left = picPaddle.Left + (picPaddle.Width / 2) - (ball.Width / 2);
            }
            
            //Update remaining lives
            private void updateItems()
            {
                scorePanel.Controls.Remove(hearts[GameData.lifes]);
                hearts[GameData.lifes] = null;
            }
        }
}
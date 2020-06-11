using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plan_B
{
    public partial class Form1 : Form
    {

        private Menu menu;
        private Top10 top;
        private UserRegister user;
        private UserControl current;
        public Form1()
        {
            InitializeComponent();
            Height = MaximumSize.Height;
            Width = MaximumSize.Width;
            WindowState = FormWindowState.Maximized;
            
            menu = new Menu();
            top = new Top10();
            user = new UserRegister();
            current = menu;
            tableLayoutPanel1.Controls.Add(current);
        }

        //This function shows a window with the scores
        private void btnScoreboard_Click(object sender, EventArgs e)
        {
            Scoreboard Score = new Scoreboard();
            Score.Show();
            this.Hide();
        }

        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menu.OnClickButtonPlay += OnClickToUseButtonPlay;
            menu.OnClickButtonTop10 += OnClickToUseButtonTop10;
            menu.OnClickButtonExit += OnClickToUseButtonExit;

            top.OnClickButtonReturn += OnClickToUseButtonTopReturn;

            user.OnClickButtonReturn += OnClickToUseButtonUserReturn;
        }

        private void OnClickToUseButtonPlay(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new UserRegister();
            tableLayoutPanel1.Controls.Add(current);
        }
        
        private void OnClickToUseButtonTop10(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new Top10();
            tableLayoutPanel1.Controls.Add(current);
        }
        
        //The button, show the selected Window to exit... 
        private void OnClickToUseButtonExit(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to exit to the game?", 
                    "Exit Button", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    
                if(result == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    //No se hace nada 
                }

            }
            catch (Exception exceptionExit)
            {
                MessageBox.Show("An error has ocurred");
            }
        }
        
        private void OnClickToUseButtonTopReturn(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new Menu();
            tableLayoutPanel1.Controls.Add(current);
        }
        
        private void OnClickToUseButtonUserReturn(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new Menu();
            tableLayoutPanel1.Controls.Add(current);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new Menu();
            tableLayoutPanel1.Controls.Add(current);
        }
    }
}
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
        public Form1()
        {
            InitializeComponent();
            Height = MaximumSize.Height;
            Width = MaximumSize.Width;
            WindowState = FormWindowState.Maximized;
        }

        //The funtion allow the entrance to a new window to register a new player
        private void btnPlay_Click(object sender, EventArgs e)
        {
            User User = new User();
            User.Show();
            this.Hide();
        }

        //This function shows a window with the scores
        private void btnScoreboard_Click(object sender, EventArgs e)
        {
            Scoreboard Score = new Scoreboard();
            Score.Show();
            this.Hide();
        }

        //The button, show the selected Window to exit... 
        private void btnExit_Click(object sender, EventArgs e)
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

       
    }
}
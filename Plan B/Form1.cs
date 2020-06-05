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
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            User User = new User();
            User.Show();
            this.Hide();
        }

        private void btnScoreboard_Click(object sender, EventArgs e)
        {
            Scoreboard Score = new Scoreboard();
            Score.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
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
    }
}
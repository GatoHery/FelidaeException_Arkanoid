using System;
using System.Windows.Forms;

namespace Plan_B
{
    public partial class Scoreboard : Form
    {
        public Scoreboard()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }
        
        //This function is a button that shows the Top 10
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery("SELECT pl.name, sc.score " + 
                                                   "FROM PLAYER pl, SCOREBOARD sc " +
                                                   "WHERE pl.idscore = sc.idscore order by sc.score desc " +
                                                   "LIMIT 10");

                dataGridView1.DataSource = dt;

            }
            catch (Exception exceptionUpdateScores)
            {
                MessageBox.Show("An error has ocurred");
            }
            
        }
        
        //If the player wants to return to main menu
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Form1 Menu = new Form1();
            Menu.Show();
            this.Close();
        }

        
    }
}
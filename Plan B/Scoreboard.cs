using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Plan_B
{
    public partial class Scoreboard : Form
    {
        public Scoreboard()
        {
            InitializeComponent();
        }
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
        private void btnReturn_Click(object sender, EventArgs e)
        {
            Form1 Menu = new Form1();
            Menu.Show();
            this.Close();
        }

       
        
    }
}
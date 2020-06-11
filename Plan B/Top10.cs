using System;
using System.Windows.Forms;

namespace Plan_B
{
    public partial class Top10 : UserControl
    {
        public delegate void EventUsuerControlTop10(object sender, EventArgs e);
        public EventUsuerControlTop10 OnClickButtonReturn;
        public Top10()
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
            if (OnClickButtonReturn != null)
            {
                OnClickButtonReturn(this, e);
            }
        }
    }
}
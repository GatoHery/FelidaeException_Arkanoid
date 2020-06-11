using System;
using System.Windows.Forms;

namespace Plan_B
{
    public partial class Menu : UserControl
    {
        public delegate void EventUsuerControlPlay(object sender, EventArgs e);
        public EventUsuerControlPlay OnClickButtonPlay;
        public EventUsuerControlPlay OnClickButtonTop10;
        public EventUsuerControlPlay OnClickButtonExit;
        public Menu()
        {
            InitializeComponent();
        }
        
        //The funtion allow the entrance to a new window to register a new player
        private void button1_Click(object sender, EventArgs e)
        {
            if (OnClickButtonPlay != null)
            {
                OnClickButtonPlay(this, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OnClickButtonTop10 != null)
            {
                OnClickButtonTop10(this, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (OnClickButtonExit != null)
            {
                OnClickButtonExit(this, e);
            }
        }
    }
}
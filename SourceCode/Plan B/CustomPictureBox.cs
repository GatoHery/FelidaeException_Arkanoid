using System.Windows.Forms;

namespace Plan_B
{
    public class CustomPictureBox : PictureBox
    {
        //This function allow to modify the hits from the ball
        public int Hits { get; set; }

        public CustomPictureBox() : base() { }
    }
}
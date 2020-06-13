using System.Windows.Forms;

namespace Plan_B
{
    public class CustomPictureBox2 : PictureBox
    {
        //This function allow to modify the lose from the hearts
        public int  lose { get; set; }

        public CustomPictureBox2() : base() { }
    }
}
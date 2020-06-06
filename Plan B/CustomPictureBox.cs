using System.Windows.Forms;

namespace Plan_B
{
    public class CustomPictureBox : PictureBox
    {
        public int Golpes { get; set; }

        public CustomPictureBox() : base() { }
    }
}
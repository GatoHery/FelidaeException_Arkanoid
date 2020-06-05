using System;
using System.Data;
using System.Windows.Forms;

namespace Plan_B
{
    public partial class User : Form
    {
        private bool Continue = true;
        public User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            
            if(name.Length == 0)
            {
                MessageBox.Show("you did not enter the name!", "Name Empty",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //verificacion con la base de datos por si esta repetido
                var dt = ConnectionDB.ExecuteQuery("SELECT Name " +
                                                             "FROM PLAYER");

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString().Equals(txtName.Text))
                    {
                        MessageBox.Show("The name already exist", "name repeated",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Continue = false;
                        break;
                    }
                }

                //luego se inicia el juego
                if (Continue == true)
                {
                    ConnectionDB.ExecuteNonQuery("INSERT INTO PLAYER(Name) " +
                                                 $"VALUES('{txtName.Text}')");
                    Game game = new Game();
                    game.Show();
                    this.Close();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Menu = new Form1();
            Menu.Show();
            this.Close();
        }
    }
}
using System;
using System.Data;
using System.Windows.Forms;

namespace Plan_B
{
    public partial class UserRegister : UserControl
    {
        private bool Continue = true;
        public delegate void EventUsuerControlUserRegister(object sender, EventArgs e);
        public EventUsuerControlUserRegister OnClickButtonReturn;
        public UserRegister()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (OnClickButtonReturn != null)
            {
                OnClickButtonReturn(this, e);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Continue = true;
            try
            {
                var name = txtName.Text;
                var player = txtName.Text;
            
                if(name.Length == 0)
                {
                    MessageBox.Show("you did not enter the name!", "Name Empty",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //verificacion con la base de datos por si esta repetido
                    var dt = ConnectionDB.ExecuteQuery("SELECT Name FROM PLAYER ");

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

                        player = txtName.Text;
                        GamePlatform game = new GamePlatform(player);
                        game.Show();
                    }
                    //Para un jugador previamente registrado 
                    else
                    {
                        player = txtName.Text;
                        GamePlatform game = new GamePlatform(player);
                        game.Show();
                    }
                }
            }
            catch (Exception exceptionNoInfo)
            {
                MessageBox.Show("An error has ocurred :(");
            }
        }
    }
}
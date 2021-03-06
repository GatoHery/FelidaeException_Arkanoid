﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Plan_B
{
    public partial class Form1 : Form
    {
        private Menu menu;
        private Top10 top;
        private UserRegister user;
        private UserControl current;
        public Form1()
        {
            InitializeComponent();
            Height = MaximumSize.Height;
            Width = MaximumSize.Width;
            WindowState = FormWindowState.Maximized;
            
            menu = new Menu();
            top = new Top10();
            user = new UserRegister();
            current = menu;
            current.Location = new Point(160,190);
            
            Controls.Add(current);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menu.OnClickButtonPlay += OnClickToUseButtonPlay;
            menu.OnClickButtonTop10 += OnClickToUseButtonTop10;
            menu.OnClickButtonExit += OnClickToUseButtonExit;

            top.OnClickButtonReturn += OnClickToUseButtonTopReturn;

            user.OnClickButtonReturn += OnClickToUseButtonUserReturn;
        }

        private void OnClickToUseButtonPlay(object sender, EventArgs e)
        {
            current.Hide();
            current = user;
            current.Location = new Point(160,190);
            Controls.Add(current);
        }
        
        private void OnClickToUseButtonTop10(object sender, EventArgs e)
        {
            current.Hide();
            current = top;
            current.Location = new Point(160,190);
            Controls.Add(current);
        }
        
        //The button, show the selected Window to exit... 
        private void OnClickToUseButtonExit(object sender, EventArgs e)
        {
            try
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
            catch (Exception exceptionExit)
            {
                MessageBox.Show("An error has ocurred");
            }
        }
        
        private void OnClickToUseButtonTopReturn(object sender, EventArgs e)
        {
            Controls.Remove(current);
            current = menu;
            current.Show();
            current.Location = new Point(160,190);
            Controls.Add(current);
        }
        
        private void OnClickToUseButtonUserReturn(object sender, EventArgs e)
        {
            Controls.Remove(current);
            current = menu;
            current.Show();
            current.Location = new Point(160,190);
            Controls.Add(current);
        }
    }
}
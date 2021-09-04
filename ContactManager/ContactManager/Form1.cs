using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class Form1 : Form
    {                
        string admin = "admin";

        public Form1()
        {
            InitializeComponent();
        }


        // Mit Klick auf Submit-Button anmelden und auf Dashboard gelangen
        private void CmdSubmit_Click(object sender, EventArgs e)
        {
            if (TxtUsername.Text == admin && TxtPassword.Text == admin)
            {
                Form_Dashboard frm = new Form_Dashboard();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The Username or the Password ist incorrect!");
            }
        }

        // Login-Label auf Hintergrund transparent setzen
        private void Form1_Load(object sender, EventArgs e)
        {
            LblLogin.Parent = pictureBox1;
            LblLogin.BackColor = Color.Transparent;
        }


        // Placeholder erstellen anhand von Enter und Leave für Username
        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            if (TxtUsername.Text == "Username")
            {
                TxtUsername.Text = "";
                TxtUsername.ForeColor = Color.Black;
            }
        }
        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            if (TxtUsername.Text == "")
            {
                TxtUsername.Text = "Username";
                TxtUsername.ForeColor = Color.Silver;
            }
        }


        // Placeholder erstellen anhand von Enter und Leave für Password
        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "Password")
            {
                TxtPassword.Text = "";
                TxtPassword.PasswordChar = '*';
                TxtPassword.ForeColor = Color.Black;
            }
        }
        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (TxtPassword.Text == "")
            {
                TxtPassword.Text = "Password";
                TxtPassword.ForeColor = Color.Silver;
            }
        }
    }
}

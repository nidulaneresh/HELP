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
    public partial class Form_Customer : Form
    {
        private ContactBook contactBook;
        private Form_Dashboard form_Dashboard;

        public Form_Customer(ContactBook contactBook, Form_Dashboard frm_Dashboard)
        {
            InitializeComponent();
            this.contactBook = contactBook;
            this.form_Dashboard = frm_Dashboard;
        }


        // Dashboard-Icon-Hintergrund Transparent setzen
        private void Form_Customer_Load(object sender, EventArgs e)
        {
            PbBackToDashboard.Parent = pictureBox1;
            PbBackToDashboard.BackColor = Color.Transparent;

            LblDashboard.Parent = pictureBox1;
            LblDashboard.BackColor = Color.Transparent;

            LblHistory.Parent = pictureBox1;
            LblHistory.BackColor = Color.Transparent;
        }


        // Anhand mit einem Klick auf Dashboard-Icon zurück zum Dashboard gelangen
        private void PbBackToDashboard_Click_1(object sender, EventArgs e)
        {
            form_Dashboard.Show();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            form_Dashboard.Show();
            base.OnFormClosing(e);
        }
    }
}

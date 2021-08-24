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
    public partial class Form_Dashboard : Form
    {
        private ContactBook contactBook = new ContactBook();

        public Form_Dashboard()
        {
            InitializeComponent();
        }


        // Mit Klick auf Bild zur Employee-Verwaltung gelangen
        private void PbEmployee_Click(object sender, EventArgs e)
        {
            Form_Employee frmEmployee = new Form_Employee(contactBook, this);
            frmEmployee.Show();
            this.Hide();
        }

        // Mit Klick auf Bild zur Contact Doc gelangen
        private void PbContactDoc_Click(object sender, EventArgs e)
        {
            Form_ContactDoc frmContactDoc = new Form_ContactDoc(contactBook, this);
            frmContactDoc.Show();
            this.Hide();
        }

        // Mit Klick auf Bild zur Customer-Verwaltung gelangen
        private void PbCustomer_Click(object sender, EventArgs e)
        {
            Form_Customer frmCustomer = new Form_Customer(contactBook, this);
            frmCustomer.Show();
            this.Hide();
        }

        private void Form_Dashboard_Load(object sender, EventArgs e)
        {
            //Stammdaten ContactBook speichern
            Disk.SaveContactBookInitialData();

            //Stammdaten ContactBook laden
            contactBook = Disk.Load();
            contactBook.FillEmployeeTable();

            //Stammdaten ContactBook speichern
            if(contactBook.ContactDocs.Count == 0)
            {
                Disk.SaveContactDocInitialData();
            }
            contactBook.ContactDocs = Disk.LoadContactDocs().ToDictionary(d => d.Id);

            //Fill contactdocs to datatable
            contactBook.FillContactDocTable();
        }
    }
}




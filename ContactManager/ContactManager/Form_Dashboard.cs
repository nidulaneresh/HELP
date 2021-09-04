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
            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;

            //Stammdaten ContactBook speichern
            //Disk.SaveContactBookInitialData();

            //Stammdaten ContactBook laden
            contactBook = Disk.Load();

            if(contactBook == null)
            {
                contactBook = new ContactBook();
            }

            contactBook.ConvertEmployeesToTraineesJSON();

            EmployeeStatistics();

            //Stammdaten ContactBook speichern
            /*
            if(contactBook.ContactDocs.Count == 0)
            {
                Disk.SaveContactDocInitialData();
            }
            contactBook.ContactDocs = Disk.LoadContactDocs().ToDictionary(d => d.Id);
            */

            //Fill contactdocs to datatable
            //contactBook.FillContactDocTable();
        }
        
        private void EmployeeStatistics()
        {
            int activeCount = 0;
            int totalTraineesCount = 0;
            int activeTraineesCount = 0;
       
            foreach(KeyValuePair<int, Employee> employee in contactBook.Employees)
            {
                if (employee.Value.Status == "aktiv")
                {
                    activeCount++;
                }
                //Traineecheck
                if (employee.Value is Trainee)
                {
                    totalTraineesCount++;

                    if (employee.Value.Status == "aktiv")
                    {
                        activeTraineesCount++;
                    }
                }
            }
            
            LblTotalEmplCount.Text = "Total Employees: " + contactBook.Employees.Count();
            LblEmplCountActive.Text = "Active: " + activeCount + " Inactive: " + (contactBook.Employees.Count() - activeCount);
            LblTotalTraineeCount.Text = "of which are Trainees: " + totalTraineesCount;
            LblTraineeActive.Text = "Active: " + activeTraineesCount + " Inactive: " + (totalTraineesCount - activeTraineesCount);
            LblEmployeeEditCount.Text = "Total Edits: " + contactBook.History.EmployeeHistory.Count();
        }
    }
}




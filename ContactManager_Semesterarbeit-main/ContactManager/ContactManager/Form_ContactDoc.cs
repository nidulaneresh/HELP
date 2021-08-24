using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class Form_ContactDoc : Form
    {
        private ContactBook contactBook;
        private Form_Dashboard form_Dashboard;

        public Form_ContactDoc(ContactBook contactBook, Form_Dashboard frm_Dashboard)
        {
            InitializeComponent();
            this.contactBook = contactBook;
            this.form_Dashboard = frm_Dashboard;
        }

        // Dashboard-Icon-Hintergrund Transparent setzen
        private void Form_ContactDoc_Load(object sender, EventArgs e)
        {
            PbBackToDashboard.Parent = pictureBox1;
            PbBackToDashboard.BackColor = Color.Transparent;

            LblDashboard.Parent = pictureBox1;
            LblDashboard.BackColor = Color.Transparent;

            ContactGridview.DataSource = contactBook.ContactDocTable;
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

        private void CmdCreateEmployee_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void CmdModifyEmployee_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void CmdDeleteEmployee_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void CmdSaveEmployee_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void BtnImportCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog  
            {  
                InitialDirectory = @"C:\",
                Title = "Import ContactDocs CSV",  
  
                CheckFileExists = true,  
                CheckPathExists = true,  
  
                DefaultExt = "csv",  
                Filter = "csv files (*.csv)|*.csv",  
                FilterIndex = 2,  
                RestoreDirectory = true,  
  
                ReadOnlyChecked = true,  
                ShowReadOnly = true  
            };  
  
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  
            {  
                //todo import from file
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                List<string> listC = new List<string>();
                List<string> listD = new List<string>();
                List<string> listE = new List<string>();

                using (var reader = new StreamReader(openFileDialog1.FileName))
                {
                  while (!reader.EndOfStream)
                  {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                    listC.Add(values[2]);
                    listD.Add(values[3]);
                    listE.Add(values[4]);
                  }
                }

                //TODO: nicht schön !
                for(int i = 0; i < listA.Count; i++)
                {
                  var id = contactBook.ContactDocs.Count + 1;
                  var c = new Customer(1);
                  c.Vorname = listB[i].Split(' ').First();
                  c.Nachname = listB[i].Split(' ').Last();
                  var empl = new Employee(1);
                  empl.Vorname = listC[i].Split(' ').First();
                  empl.Nachname = listC[i].Split(' ').Last();
                  contactBook.ContactDocs.Add(id, new ContactDoc(int.Parse(listA[i]), c, empl, listE[i], DateTime.Parse(listD[i])));
                }

                contactBook.FillContactDocTable();
                
                ContactGridview.DataSource = contactBook.ContactDocTable;
            }
        }

        private void TxtSearchDB_Enter(object sender, EventArgs e)
        {
            //TODO
        }
    }
}

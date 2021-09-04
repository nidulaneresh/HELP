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
    public partial class Form_Customer : Form
    {
        // --------------------------------------------------------------------------------------------------- //
        // TABLE OF CONTENT
        // --------------------------------------------------------------------------------------------------- //
        // 1. PROPERTIES
        // 2. FORM LOAD/CLOSE & CONSTRUCTOR
        // 3. CREATE / MODIFY / DELETE / SAVE / CANCEL
        // 4. FILTER & SEARCH
        // 5. DATEPICKER & COMBOBOX
        // 6. GUI SETTINGS


        // --------------------------------------------------------------------------------------------------- //
        // PROPERTIES
        // --------------------------------------------------------------------------------------------------- //
        private ContactBook contactBook;
        private Form_Dashboard form_Dashboard;
        private DataGridChef dataGridChef;

        private DateTimePicker oDateTimePicker;
        private ComboBox oComboBox;

        //Define comboBox and datePicker columns
        private readonly List<int> comboBoxColumnIndices = new List<int>() { 1, 5, 8, 17 };
        private readonly List<int> datePickerColumnIndices = new List<int>() { 4 };

        //Define mandatory fields
        private readonly List<int> mandatoryFieldsCustomer = new List<int>() { 1, 2, 3, 4, 7, 8 };


        // --------------------------------------------------------------------------------------------------- //
        // FORM LOAD/CLOSE & CONSTRUCTOR
        // --------------------------------------------------------------------------------------------------- //
        public Form_Customer(ContactBook contactBook, Form_Dashboard frm_Dashboard)
        {
            InitializeComponent();

            //Set references
            this.contactBook = contactBook;
            this.form_Dashboard = frm_Dashboard;

            //Initialize DataGridChef
            dataGridChef = new DataGridChef(GrdCustomer, comboBoxColumnIndices, datePickerColumnIndices);
        }

        //Dashboard-Icon-Hintergrund Transparent setzen
        private void Form_Customer_Load(object sender, EventArgs e)
        {
            SetColorofGUIElements();

            //Define DataGridView
            GrdCustomer.DataSource = contactBook.CustomerTable;
            dataGridChef.InitialTableDefinition();

            TxtHistory.Text = contactBook.History.UpdateHistoryTextField(contactBook.History.CustomerHistory);

            SetGUIToViewMode();
        }

        //Anhand mit einem Klick auf Dashboard-Icon zurück zum Dashboard gelangen
        private void PbBackToDashboard_Click_1(object sender, EventArgs e)
        {
            form_Dashboard.Show();
            this.Close();
        }

        //Makes sure Dashboard is shown again when form is closed
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            form_Dashboard.Show();
            base.OnFormClosing(e);
        }


        // --------------------------------------------------------------------------------------------------- //
        // CREATE / MODIFY / DELETE / SAVE / CANCEL
        // --------------------------------------------------------------------------------------------------- //
        private void CmdCreateCustomer_Click(object sender, EventArgs e)
        {
            //Add row, format it, count counter up, insert id
            contactBook.CustomerTable.Rows.Add();
            dataGridChef.FormatRowModifiable(dataGridChef.FindModifiableRow(), mandatoryFieldsCustomer);
            contactBook.CustomerCounter++;
            dataGridChef.FindModifiableRow().Cells[0].Value = contactBook.CustomerCounter;

            SetGUIToModifyMode();
        }

        private void CmdModifyCustomer_Click(object sender, EventArgs e)
        {
            dataGridChef.FormatRowModifiable(GrdCustomer.CurrentRow, mandatoryFieldsCustomer);
            GrdCustomer.ClearSelection();
            SetGUIToModifyMode();
        }

        private void CmdDeleteCustomer_Click(object sender, EventArgs e)
        {
            int index = GrdCustomer.CurrentCell.RowIndex;
            int customerNumber = Convert.ToInt32(GrdCustomer.Rows[index].Cells[0].Value);

            //Check if a ContactDoc is linked to this customer
            foreach (KeyValuePair<int, ContactDoc> contactDocEntry in contactBook.ContactDocs)
            {
                if (contactDocEntry.Value.EmployeeId == customerNumber)
                {
                    MessageBox.Show("Cannot delete an employee that is linked to one or more ContactDocs! Either delete the referenced ContactDocs first or consider setting the employee to inactive instead");
                    return;
                }
            }

            //User gets prompted to confirm delete
            string messageBoxText = "Do you really want to delete?";
            string caption = "Delete";
            MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
            MessageBoxIcon icon = MessageBoxIcon.Warning;

            var result = MessageBox.Show(messageBoxText, caption, button, icon);

            if (result == DialogResult.Yes)
            {
                //Write in the History
                contactBook.History.DeletedCustomer(contactBook.Customers[customerNumber]);

                //Remove customer everywhere
                contactBook.Customers.Remove(customerNumber);
                contactBook.CustomerTable.Rows.RemoveAt(index);
            }

            //Update History Textfield
            TxtHistory.Text = contactBook.History.UpdateHistoryTextField(contactBook.History.CustomerHistory);

            Disk.Save(contactBook);
        }

        private void CmdSaveCustomer_Click(object sender, EventArgs e)
        {
            int unlockedRowIndex = dataGridChef.FindModifiableRow().Index;

            KillDateTimePickerOrComboBox();

            //Check if mandatory fields are filled
            if (dataGridChef.AllMandatoryFieldsFilled(mandatoryFieldsCustomer))
            {
                Customer customer = Customer.CreateFromDataGridViewRow(GrdCustomer.Rows[unlockedRowIndex]);

                if (contactBook.Customers.ContainsKey(customer.CustomerNumber))
                {
                    //Modify an existing Customer
                    contactBook.History.UpdatedCustomer(contactBook.Customers[customer.CustomerNumber], customer);
                    contactBook.Customers[customer.CustomerNumber] = customer;
                }
                else
                {
                    //Create a new Customer
                    contactBook.Customers.Add(customer.CustomerNumber, customer);
                    contactBook.History.NewCustomer(customer);
                }

                dataGridChef.FormatRowReadOnly(dataGridChef.FindModifiableRow());

                SetGUIToViewMode();

                TxtHistory.Text = contactBook.History.UpdateHistoryTextField(contactBook.History.CustomerHistory);
            }
            else
            {
                MessageBox.Show("Not all mandatory Fields are filled! Please fill out the highlighted fields.");
            }
            Disk.Save(contactBook);
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            KillDateTimePickerOrComboBox();

            int customerNumber = Convert.ToInt32(dataGridChef.FindModifiableRow().Cells[0].Value.ToString());

            //Check if customer is already existing
            if (contactBook.Customers.ContainsKey(customerNumber))
            {
                int rowIndex = dataGridChef.FindModifiableRow().Index;

                //Reload existing customer
                DataRow dataRow = contactBook.Customers[customerNumber].GetDataRow(contactBook.CustomerTable);
                contactBook.CustomerTable.Rows.RemoveAt(rowIndex);
                contactBook.CustomerTable.Rows.InsertAt(dataRow, rowIndex);
            }
            else
            {
                //Just remove empty row again, reduce Customer Count
                GrdCustomer.Rows.Remove(dataGridChef.FindModifiableRow());
                contactBook.CustomerCounter--;
            }

            dataGridChef.FormatRowReadOnly(dataGridChef.FindModifiableRow());

            SetGUIToViewMode();
        }


        // --------------------------------------------------------------------------------------------------- //
        // FILTER & SEARCH
        // --------------------------------------------------------------------------------------------------- //

        private void TxtSearchDB_TextChanged(object sender, EventArgs e)
        {
            //Search Function
            (GrdCustomer.DataSource as DataTable).DefaultView.RowFilter = String.Format(
                "Convert(customerNumber, System.String) LIKE '%{0}%' OR " +
                "Salutation LIKE '%{0}%' OR " +
                "Firstname LIKE '%{0}%' OR " +
                "Lastname LIKE '%{0}%' OR " +
                "Gender LIKE '%{0}%' OR " +
                "`Mobile Number` LIKE '%{0}%' OR " +
                "eMail LIKE '%{0}%' OR " +
                "Status LIKE '%{0}%' OR " +
                "`AHV Number` LIKE '%{0}%' OR " +
                "Location LIKE '%{0}%' OR " +
                "Nationality LIKE '%{0}%' OR " +
                "Adress LIKE '%{0}%' OR " +
                "`Zip Code` LIKE '%{0}%' OR " +
                "`Phone Number Privat` LIKE '%{0}%' OR " +
                "`Company Name` LIKE '%{0}%' OR " +
                "`Business Address` LIKE '%{0}%' OR " +
                "`Customer TYP` LIKE '%{0}%' OR " +
                "`Customer Contact` LIKE '%{0}%'"
                , TxtSearchDB.Text);
        }


        // --------------------------------------------------------------------------------------------------- //
        // DATEPICKER & COMBOBOX
        // --------------------------------------------------------------------------------------------------- //

        //Gets fired if a cell gets clicked. Decides whether a comboBox or a datePicker should be shown and creates corresponding event handlers
        private void GrdCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Decide if comboBox or datePicker should be called
            if (e.RowIndex != -1 && dataGridChef.SelectedCell == null && comboBoxColumnIndices.Contains(e.ColumnIndex) && !GrdCustomer.Rows[e.RowIndex].ReadOnly)
            {
                oComboBox = dataGridChef.createComboBox(e, ChooseComboBoxDataSource(e.ColumnIndex));
                oComboBox.DropDownClosed += new EventHandler(oComboBox_CloseUp);
            }
            else if (e.RowIndex != -1 && dataGridChef.SelectedCell == null && datePickerColumnIndices.Contains(e.ColumnIndex) && !GrdCustomer.Rows[e.RowIndex].ReadOnly)
            {
                oDateTimePicker = dataGridChef.CreateDateTimePicker(e);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);
                oDateTimePicker.Leave += new EventHandler(oDateTimePicker_CloseUp);
                oDateTimePicker.LostFocus += new EventHandler(oDateTimePicker_CloseUp);
            }
            //If a datepicker or comboBox is already open, prompt the user to make a selection there first
            else if (e.RowIndex != -1 && dataGridChef.SelectedCell != null && !GrdCustomer.Rows[e.RowIndex].ReadOnly && ((comboBoxColumnIndices.Contains(e.ColumnIndex) || datePickerColumnIndices.Contains(e.ColumnIndex)) && (oComboBox != null && oComboBox.Visible == true) || (oDateTimePicker != null && oDateTimePicker.Visible == true)))
            {
                MessageBox.Show("There is already a ComboBox or DateTimePicker in column #" + dataGridChef.SelectedCell.ColumnIndex + " " + '"' + GrdCustomer.Columns[dataGridChef.SelectedCell.ColumnIndex].HeaderText + '"' + " open, please select a value there first.");
                GrdCustomer.CurrentCell = dataGridChef.SelectedCell;
            }
        }
        
        public void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use  
            if (dataGridChef.SelectedCell != null)
            {
                dataGridChef.SelectedCell.Value = oDateTimePicker.Text.ToString();
            }
            oDateTimePicker.Visible = false;
            dataGridChef.SelectedCell = null;
        }

        public void oComboBox_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use  
            dataGridChef.SelectedCell.Value = oComboBox.SelectedValue;
            oComboBox.Visible = false;
            dataGridChef.SelectedCell = null;
        }

        ///<summary>
        ///Kills potentially active DateTimePicker or ComboBox
        ///</summary>
        private void KillDateTimePickerOrComboBox()
        {
            if (oDateTimePicker != null)
            {
                oDateTimePicker.Visible = false;
                dataGridChef.SelectedCell = null;
            }
            else if (oComboBox != null)
            {
                oComboBox.Visible = false;
                dataGridChef.SelectedCell = null;
            }
        }

        ///<summary>
        ///Decide which ComboBox Options should be shown based on columnIndex. Returns corresponding List
        ///</summary>
        private List<string> ChooseComboBoxDataSource(int columnIndex)
        {
            List<string> comboBoxDataSource = new List<string>();

            switch (columnIndex)
            {
                case 1:
                    comboBoxDataSource = Person.SalutationOptions;
                    break;

                case 5:
                    comboBoxDataSource = Person.GenderOptions;
                    break;

                case 8:
                    comboBoxDataSource = Person.StatusOptions;
                    break;

                case 17:
                    comboBoxDataSource = Customer.CustomerTypeOptions;
                    break;
            }

            return comboBoxDataSource;
        }

        //Update comboBox or datePicker location when user is scrolling through dataGridView
        private void GrdCustomer_Scroll(object sender, ScrollEventArgs e)
        {
            //Decide if combobox or datepicker is active
            if (oComboBox != null && oComboBox.Visible == true)
            {
                dataGridChef.UpdateControlPosition(oComboBox);
            }
            else if (oDateTimePicker != null && oDateTimePicker.Visible == true)
            {
                dataGridChef.UpdateControlPosition(oDateTimePicker);
            }
        }


        // --------------------------------------------------------------------------------------------------- //
        // GUI SETTINGS
        // --------------------------------------------------------------------------------------------------- //

        ///<summary>
        ///Activates and deactives buttons and textfields for GUI "modify mode"
        ///</summary>
        private void SetGUIToModifyMode()
        {
            CmdCreateCustomer.Enabled = false;
            CmdModifyCustomer.Enabled = false;
            CmdDeleteCustomer.Enabled = false;
            CmdSaveCustomer.Enabled = true;
            CmdCancel.Enabled = true;
        }

        ///<summary>
        ///Activates and deactives buttons and textfields for GUI "view mode"
        ///</summary>
        private void SetGUIToViewMode()
        {
            CmdCreateCustomer.Enabled = true;
            CmdModifyCustomer.Enabled = true;
            CmdDeleteCustomer.Enabled = true;
            CmdSaveCustomer.Enabled = false;
            CmdCancel.Enabled = false;
        }

        ///<summary>
        ///Initial setting of colors and references of GUI elements
        ///</summary>
        private void SetColorofGUIElements()
        {
            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;

            PbBackToDashboard.Parent = pictureBox1;
            PbBackToDashboard.BackColor = Color.Transparent;

            LblDashboard.Parent = pictureBox1;
            LblDashboard.BackColor = Color.Transparent;

            LblHistory.Parent = pictureBox1;
            LblHistory.BackColor = Color.Transparent;

            LblLegend.Parent = pictureBox1;
            LblLegend.BackColor = Color.Transparent;

            LblMandatoryField.Parent = pictureBox1;
            LblMandatoryField.BackColor = Color.Transparent;

            LblModifiableField.Parent = pictureBox1;
            LblModifiableField.BackColor = Color.Transparent;

            LblReadOnlyField.Parent = pictureBox1;
            LblReadOnlyField.BackColor = Color.Transparent;
        }

        ///<summary>
        ///Import CSV
        ///</summary>
        private void CmdCSVImport_Click(object sender, EventArgs e)
        {
            /*
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
                for (int i = 0; i < listA.Count; i++)
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

                GrdContactDocs.DataSource = contactBook.ContactDocTable;
            }
            */
        }

        private void CmdVCardImport_Click(object sender, EventArgs e)
        {

        }
    }    
}

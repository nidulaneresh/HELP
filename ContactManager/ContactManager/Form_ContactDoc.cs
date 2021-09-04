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
        private readonly List<int> comboBoxColumnIndices = new List<int>() { 1, 2 };
        private readonly List<int> datePickerColumnIndices = new List<int>() { 3 };

        //Define mandatory fields
        private readonly List<int> mandatoryFieldsContactDoc = new List<int>() { 1, 2, 3, 4 };

        // --------------------------------------------------------------------------------------------------- //
        // FORM LOAD/CLOSE & CONSTRUCTOR
        // --------------------------------------------------------------------------------------------------- //
        public Form_ContactDoc(ContactBook contactBook, Form_Dashboard frm_Dashboard)
        {
            InitializeComponent();

            //Set references
            this.contactBook = contactBook;
            this.form_Dashboard = frm_Dashboard;

            //Initialize DataGridChef
            dataGridChef = new DataGridChef(GrdContactDocs, comboBoxColumnIndices, datePickerColumnIndices);
        }

        // Dashboard-Icon-Hintergrund Transparent setzen
        private void Form_ContactDoc_Load(object sender, EventArgs e)
        {
            SetColorOfGUIElements();
            DefineDataGridView();
            TxtHistory.Text = contactBook.History.UpdateHistoryTextField(contactBook.History.ContactDocHistory);
            SetGUIToViewMode();
        }

        // Anhand mit einem Klick auf Dashboard-Icon zurück zum Dashboard gelangen
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
        private void CmdCreateContactDoc_Click(object sender, EventArgs e)
        {
            //Add row, format it, count counter up, insert id
            contactBook.ContactDocTable.Rows.Add();
            dataGridChef.FormatRowModifiable(dataGridChef.FindModifiableRow(), mandatoryFieldsContactDoc);
            contactBook.ContactDocCounter++;
            dataGridChef.FindModifiableRow().Cells[0].Value = contactBook.ContactDocCounter;

            SetGUIToModifyMode();
        }

        private void CmdModifyContactDoc_Click(object sender, EventArgs e)
        {
            dataGridChef.FormatRowModifiable(GrdContactDocs.CurrentRow, mandatoryFieldsContactDoc);
            GrdContactDocs.ClearSelection();
            SetGUIToModifyMode();
        }

        private void CmdDeleteContactDoc_Click(object sender, EventArgs e)
        {
            int index = GrdContactDocs.CurrentCell.RowIndex;
            int contactDocNumber = Convert.ToInt32(GrdContactDocs.Rows[index].Cells[0].Value);

            //User gets prompted to confirm delete
            string messageBoxText = "Do you really want to delete?";
            string caption = "Delete";
            MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
            MessageBoxIcon icon = MessageBoxIcon.Warning;

            var result = MessageBox.Show(messageBoxText, caption, button, icon);

            if (result == DialogResult.Yes)
            {
                // Write in the History
                contactBook.History.DeletedContactDoc(contactBook.ContactDocs[contactDocNumber]);

                //Remove contactDoc everywhere
                contactBook.ContactDocs.Remove(contactDocNumber);
                contactBook.ContactDocTable.Rows.RemoveAt(index);
            }

            //Update History Textfield
            TxtHistory.Text = contactBook.History.UpdateHistoryTextField(contactBook.History.ContactDocHistory);

            Disk.Save(contactBook);
        }

        private void CmdSaveContactDoc_Click(object sender, EventArgs e)
        {
            int unlockedRowIndex = dataGridChef.FindModifiableRow().Index;

            KillDateTimePickerOrComboBox();

            //Check if mandatory fields are filled
            if (dataGridChef.AllMandatoryFieldsFilled(mandatoryFieldsContactDoc))
            {
                ContactDoc contactDoc = ContactDoc.CreateFromDataGridViewRow(GrdContactDocs.Rows[unlockedRowIndex], contactBook);

                if (contactBook.ContactDocs.ContainsKey(contactDoc.Id))
                {
                    //Modify an existing contactDoc
                    contactBook.History.UpdatedContactDoc(contactBook.ContactDocs[contactDoc.Id], contactDoc);
                    contactBook.ContactDocs[contactDoc.Id] = contactDoc;
                }
                else
                {
                    //Create a new contactDoc
                    contactBook.ContactDocs.Add(contactDoc.Id, contactDoc);
                    contactBook.History.NewContactDoc(contactDoc);
                }

                dataGridChef.FormatRowReadOnly(dataGridChef.FindModifiableRow());

                SetGUIToViewMode();

                TxtHistory.Text = contactBook.History.UpdateHistoryTextField(contactBook.History.ContactDocHistory);
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

            int contactDocId = Convert.ToInt32(dataGridChef.FindModifiableRow().Cells[0].Value.ToString());

            //Check if contactDoc is already existing
            if (contactBook.Employees.ContainsKey(contactDocId))
            {
                int rowIndex = dataGridChef.FindModifiableRow().Index;

                //Reload existing contactDoc
                DataRow dataRow = contactBook.ContactDocs[contactDocId].GetDataRow(contactBook.ContactDocTable, contactBook);
                contactBook.ContactDocTable.Rows.RemoveAt(rowIndex);
                contactBook.ContactDocTable.Rows.InsertAt(dataRow, rowIndex);
            }
            else
            {
                //Just remove empty row again, reduce employeeCount
                GrdContactDocs.Rows.Remove(dataGridChef.FindModifiableRow());
                contactBook.ContactDocCounter--;
            }

            dataGridChef.FormatRowReadOnly(dataGridChef.FindModifiableRow());

            SetGUIToViewMode();
        }

        // --------------------------------------------------------------------------------------------------- //
        // FILTER & SEARCH
        // --------------------------------------------------------------------------------------------------- //
        private void TxtSearchDB_Enter(object sender, EventArgs e)
        {
            //TODO
        }


        // --------------------------------------------------------------------------------------------------- //
        // DATEPICKER & COMBOBOX
        // --------------------------------------------------------------------------------------------------- //
        
        //Gets fired if a cell gets clicked. Decides whether a comboBox or a datePicker should be shown and creates corresponding event handlers
        private void GrdContactDocs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Decide if comboBox or datePicker should be called
            if (e.RowIndex != -1 && dataGridChef.SelectedCell == null && comboBoxColumnIndices.Contains(e.ColumnIndex) && !GrdContactDocs.Rows[e.RowIndex].ReadOnly)
            {
                oComboBox = dataGridChef.createComboBox(e, ChooseComboBoxDataSource(e.ColumnIndex));
                oComboBox.DropDownClosed += new EventHandler(oComboBox_CloseUp);
            }
            else if (e.RowIndex != -1 && dataGridChef.SelectedCell == null && datePickerColumnIndices.Contains(e.ColumnIndex) && !GrdContactDocs.Rows[e.RowIndex].ReadOnly)
            {
                oDateTimePicker = dataGridChef.CreateDateTimePicker(e);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);
                oDateTimePicker.Leave += new EventHandler(oDateTimePicker_CloseUp);
                oDateTimePicker.LostFocus += new EventHandler(oDateTimePicker_CloseUp);
            }
            //If a datepicker or comboBox is already open, prompt the user to make a selection there first
            else if (e.RowIndex != -1 && dataGridChef.SelectedCell != null && !GrdContactDocs.Rows[e.RowIndex].ReadOnly && ((comboBoxColumnIndices.Contains(e.ColumnIndex) || datePickerColumnIndices.Contains(e.ColumnIndex)) && (oComboBox != null && oComboBox.Visible == true) || (oDateTimePicker != null && oDateTimePicker.Visible == true)))
            {
                MessageBox.Show("There is already a ComboBox or DateTimePicker in column #" + dataGridChef.SelectedCell.ColumnIndex + " " + '"' + GrdContactDocs.Columns[dataGridChef.SelectedCell.ColumnIndex].HeaderText + '"' + " open, please select a value there first.");
                GrdContactDocs.CurrentCell = dataGridChef.SelectedCell;
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
                    comboBoxDataSource = Customer.ContactDocOptions(contactBook.Customers);
                    break;

                case 2:
                    comboBoxDataSource = Employee.ContactDocOptions(contactBook.Employees);
                    break;
            }

            return comboBoxDataSource;
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
            //Check for customer or employee "list ist empty" warning, prevent filling this in
            if (!oComboBox.SelectedValue.ToString().Contains("list is empty"))
            {
                dataGridChef.SelectedCell.Value = oComboBox.SelectedValue;
            }
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


        // --------------------------------------------------------------------------------------------------- //
        // GUI SETTINGS
        // --------------------------------------------------------------------------------------------------- //
        
        ///<summary>
        ///Define DataGridView
        ///</summary>
        private void DefineDataGridView()
        {
            GrdContactDocs.DataSource = contactBook.ContactDocTable;
            contactBook.FillContactDocTable();
            dataGridChef.InitialTableDefinition();
            GrdContactDocs.Columns[0].Width = 40;
            GrdContactDocs.Columns[1].Width = 250;
            GrdContactDocs.Columns[2].Width = 250;
            GrdContactDocs.Columns[3].Width = 100;
        }

        ///<summary>
        ///Initial setting of colors and references of GUI elements
        ///</summary>
        private void SetColorOfGUIElements()
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
        ///Activates and deactives buttons and textfields for GUI "modify mode"
        ///</summary>
        private void SetGUIToModifyMode()
        {
            CmdCreateContactDoc.Enabled = false;
            CmdModifyContactDoc.Enabled = false;
            CmdDeleteContactDoc.Enabled = false;
            CmdSaveContactDoc.Enabled = true;
            CmdCancel.Enabled = true;
        }

        ///<summary>
        ///Activates and deactives buttons and textfields for GUI "view mode"
        ///</summary>
        private void SetGUIToViewMode()
        {
            CmdCreateContactDoc.Enabled = true;
            CmdModifyContactDoc.Enabled = true;
            CmdDeleteContactDoc.Enabled = true;
            CmdSaveContactDoc.Enabled = false;
            CmdCancel.Enabled = false;
        }

        private void TxtSearchDB_TextChanged(object sender, EventArgs e)
        {
            (GrdContactDocs.DataSource as DataTable).DefaultView.RowFilter = String.Format(
                "Convert(id, System.String) LIKE '%{0}%'"// OR +
             //   "Convert(CustomerId, System.String) LIKE '%{0}%' OR " +
             //  "Convert(employeeId, System.String) LIKE '%{0}%' OR " +
             //  "Notes LIKE '%{0}%' OR " + 
             //   "Convert(datum, System.String) LIKE '%{0}%'"
                , TxtSearchDB.Text);
        }
    }
}

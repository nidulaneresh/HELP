using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class Form_Employee : Form
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
        private readonly List<int> comboBoxColumnIndices = new List<int>() { 1, 5, 8, 23 };
        private readonly List<int> datePickerColumnIndices = new List<int>() { 4, 19, 20 };

        //Define mandatory fields
        private readonly List<int> mandatoryFieldsEmployee = new List<int>() { 1, 2, 3, 4, 7, 8, 19 };
        private List<int> mandatoryFieldsTrainee;


        // --------------------------------------------------------------------------------------------------- //
        // FORM LOAD/CLOSE & CONSTRUCTOR
        // --------------------------------------------------------------------------------------------------- //
        public Form_Employee(ContactBook contactBook, Form_Dashboard frm_Dashboard)
        {
            InitializeComponent();

            //Set references
            this.contactBook = contactBook;
            this.form_Dashboard = frm_Dashboard;

            defineMandatoryFieldsTrainee();

            //Initialize DataGridChef
            dataGridChef = new DataGridChef(GrdEmployees, comboBoxColumnIndices, datePickerColumnIndices);
        }

        private void Form_Employee_Load(object sender, EventArgs e)
        {
            SetColorOfGUIElements();

            //Define DataGridView
            GrdEmployees.DataSource = contactBook.EmployeeTable;
            dataGridChef.InitialTableDefinition();

            TxtHistory.Text = contactBook.History.UpdateHistoryTextField(contactBook.History.EmployeeHistory);

            SetGUIToViewMode();
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

        ///<summary>
        ///Creates list of mandatory fields for trainee based on employee list
        ///</summary>
        private void defineMandatoryFieldsTrainee()
        {
            mandatoryFieldsTrainee = new List<int>(mandatoryFieldsEmployee);
            mandatoryFieldsTrainee.Add(24);
            mandatoryFieldsTrainee.Add(25);
        }


        // --------------------------------------------------------------------------------------------------- //
        // CREATE / MODIFY / DELETE / SAVE / CANCEL
        // --------------------------------------------------------------------------------------------------- //

        private void CmdCreateEmployee_Click(object sender, EventArgs e)
        {
            //Add row, format it, count counter up, insert id
            contactBook.EmployeeTable.Rows.Add();
            dataGridChef.FormatRowModifiable(dataGridChef.FindModifiableRow(), mandatoryFieldsEmployee);
            dataGridChef.LockTraineeFieldsForEmployee();
            contactBook.EmployeeCounter++;
            dataGridChef.FindModifiableRow().Cells[0].Value = contactBook.EmployeeCounter;

            SetGUIToModifyMode();
        }

        private void CmdCreateTrainee_Click(object sender, EventArgs e)
        {
            //Add row, format it, count counter up, insert id
            contactBook.EmployeeTable.Rows.Add();
            dataGridChef.FormatRowModifiable(dataGridChef.FindModifiableRow(), mandatoryFieldsTrainee);
            contactBook.EmployeeCounter++;
            dataGridChef.FindModifiableRow().Cells[0].Value = contactBook.EmployeeCounter;

            SetGUIToModifyMode();

            TxtHistory.Text = contactBook.History.UpdateHistoryTextField(contactBook.History.EmployeeHistory);
        }

        private void CmdModifyEmployee_Click(object sender, EventArgs e)
        {
            int index = GrdEmployees.CurrentCell.RowIndex;
            int employeeNumber = Convert.ToInt32(GrdEmployees.Rows[index].Cells[0].Value);

            //Decide if modified employee is trainee or employee only
            if (contactBook.Employees[employeeNumber] is Trainee)
            {
                dataGridChef.FormatRowModifiable(GrdEmployees.CurrentRow, mandatoryFieldsTrainee);
            }
            else
            {
                dataGridChef.FormatRowModifiable(GrdEmployees.CurrentRow, mandatoryFieldsEmployee);
                dataGridChef.LockTraineeFieldsForEmployee();
            }

            GrdEmployees.ClearSelection();
            SetGUIToModifyMode();
        }

        private void CmdDeleteEmployee_Click(object sender, EventArgs e)
        {
            int index = GrdEmployees.CurrentCell.RowIndex;
            int employeeNumber = Convert.ToInt32(GrdEmployees.Rows[index].Cells[0].Value);

            //Check if a ContactDoc is linked to this customer
            foreach (KeyValuePair<int, ContactDoc> contactDocEntry in contactBook.ContactDocs)
            {
                if (contactDocEntry.Value.EmployeeId == employeeNumber)
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
                // Write in the History
                contactBook.History.DeletedEmployee(contactBook.Employees[employeeNumber]);

                //Remove employee everywhere
                contactBook.Employees.Remove(employeeNumber);
                contactBook.EmployeeTable.Rows.RemoveAt(index);
            }

            //Update History Textfield
            TxtHistory.Text = contactBook.History.UpdateHistoryTextField(contactBook.History.EmployeeHistory);

            Disk.Save(contactBook);
        }

        private void CmdSaveEmployee_Click(object sender, EventArgs e)
        {
            int unlockedRowIndex = dataGridChef.FindModifiableRow().Index;

            KillDateTimePickerOrComboBox();

            //Check if mandatory fields are filled
            if (CheckForMandatoryFields())
            {
                //Decides if employee or trainee needs to be modified
                if (GrdEmployees.Rows[unlockedRowIndex].Cells[24].Value.ToString() == String.Empty)
                {
                    Employee employee = Employee.CreateFromDataGridViewRow(GrdEmployees.Rows[unlockedRowIndex]);

                    if (contactBook.Employees.ContainsKey(employee.EmployeeNumber))
                    {
                        //Modify an existing employee
                        contactBook.History.UpdatedEmployee(contactBook.Employees[employee.EmployeeNumber], employee);
                        contactBook.Employees[employee.EmployeeNumber] = employee;
                    }
                    else
                    {
                        //Create a new employee
                        contactBook.Employees.Add(employee.EmployeeNumber, employee);
                        contactBook.History.NewEmployee(employee);
                    }
                }
                else
                {
                    Trainee trainee = Trainee.CreateFromDataGridViewRow(GrdEmployees.Rows[unlockedRowIndex]);

                    if (contactBook.Employees.ContainsKey(trainee.EmployeeNumber))
                    {
                        //Modify an existing Trainee
                        contactBook.History.UpdatedEmployee(contactBook.Employees[trainee.EmployeeNumber], trainee);
                        contactBook.Employees[trainee.EmployeeNumber] = trainee;
                    }
                    else
                    {
                        //Create a new Trainee
                        contactBook.Employees.Add(trainee.EmployeeNumber, trainee);
                        contactBook.History.NewEmployee(trainee);
                    }
                }

                dataGridChef.FormatRowReadOnly(dataGridChef.FindModifiableRow());

                SetGUIToViewMode();

                TxtHistory.Text = contactBook.History.UpdateHistoryTextField(contactBook.History.EmployeeHistory);
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

            int employeeNumber = Convert.ToInt32(dataGridChef.FindModifiableRow().Cells[0].Value.ToString());

            //Check if employee is already existing
            if (contactBook.Employees.ContainsKey(employeeNumber))
            {
                int rowIndex = dataGridChef.FindModifiableRow().Index;

                //Decide if modified row is an employee or trainee
                if (contactBook.Employees[employeeNumber] is Trainee)
                {
                    //Load existing trainee
                    Trainee trainee = contactBook.Employees[employeeNumber] as Trainee;
                    DataRow dataRow = trainee.TraineeGetDataRow(contactBook.EmployeeTable);
                    contactBook.EmployeeTable.Rows.RemoveAt(rowIndex);
                    contactBook.EmployeeTable.Rows.InsertAt(dataRow, rowIndex);
                }
                else
                {
                    //Load existing employee
                    DataRow dataRow = contactBook.Employees[employeeNumber].GetDataRow(contactBook.EmployeeTable);
                    contactBook.EmployeeTable.Rows.RemoveAt(rowIndex);
                    contactBook.EmployeeTable.Rows.InsertAt(dataRow, rowIndex);
                }
            }
            else
            {
                //Just remove empty row again, reduce employeeCount
                GrdEmployees.Rows.Remove(dataGridChef.FindModifiableRow());
                contactBook.EmployeeCounter--;
            }

            dataGridChef.FormatRowReadOnly(dataGridChef.FindModifiableRow());

            SetGUIToViewMode();
        }

        //only needed as we have employees and trainees. Decides what is mandatory - in customer not needed
        private bool CheckForMandatoryFields()
        {
            DataGridViewRow modifiedRow = dataGridChef.FindModifiableRow();

            //Check if employee or trainee
            if (modifiedRow.Cells[24].ReadOnly == true)
            {
                if (dataGridChef.AllMandatoryFieldsFilled(mandatoryFieldsEmployee))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (dataGridChef.AllMandatoryFieldsFilled(mandatoryFieldsEmployee))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // --------------------------------------------------------------------------------------------------- //
        // FILTER & SEARCH
        // --------------------------------------------------------------------------------------------------- //

        //Filter rows depending on selection (employees / trainees)
        private void ChkEmployee_CheckedChanged(object sender, EventArgs e)
        {
            GrdEmployees.ClearSelection();
            GrdEmployees.CurrentCell = null;

            foreach (DataGridViewRow row in GrdEmployees.Rows)
            {
                if (row.Cells[24].Value.ToString() == String.Empty)
                {
                    if (ChkEmployee.Checked)
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
                else if (row.Cells[24].Value.ToString() != String.Empty)
                {
                    if (ChkTrainees.Checked)
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void TxtSearchDB_TextChanged(object sender, EventArgs e)
        {
            //Search Function
            (GrdEmployees.DataSource as DataTable).DefaultView.RowFilter = String.Format(
                "Convert(EmployeeNumber, System.String) LIKE '%{0}%' OR " +
                "Salutation LIKE '%{0}%' OR " +
                "Firstname LIKE '%{0}%' OR " +
                "Lastname LIKE '%{0}%' OR " +
                "Convert(Birthday, System.String) LIKE '%{0}%' OR " +
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
                "`Phone Number Business` LIKE '%{0}%' OR " +
                "`Fax Number` LIKE '%{0}%' OR " +
                "Titel LIKE '%{0}%' OR " +
                "Division LIKE '%{0}%' OR " +
                "Convert(`Date of Entry`, System.String) LIKE '%{0}%' OR " +
                "Convert(`Date of Exit`, System.String) LIKE '%{0}%' OR " +
                "`Employeement Level` LIKE '%{0}%' OR " +
                "Role LIKE '%{0}%' OR " +
                "`Cadre Level` LIKE '%{0}%' OR " +
                "`Max Trainee Years` LIKE '%{0}%' OR " +
                "`Current Trainee Year` LIKE '%{0}%'"
                , TxtSearchDB.Text);
        }


        // --------------------------------------------------------------------------------------------------- //
        // DATEPICKER & COMBOBOX
        // --------------------------------------------------------------------------------------------------- //

        //Gets fired if a cell gets clicked. Decides whether a comboBox or a datePicker should be shown and creates corresponding event handlers
        private void GrdEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Decide if comboBox or datePicker should be called
            if (e.RowIndex != -1 && dataGridChef.SelectedCell == null && comboBoxColumnIndices.Contains(e.ColumnIndex) && !GrdEmployees.Rows[e.RowIndex].ReadOnly)
            {
                oComboBox = dataGridChef.createComboBox(e, ChooseComboBoxDataSource(e.ColumnIndex));
                oComboBox.DropDownClosed += new EventHandler(oComboBox_CloseUp);
            }
            else if (e.RowIndex != -1 && dataGridChef.SelectedCell == null && datePickerColumnIndices.Contains(e.ColumnIndex) && !GrdEmployees.Rows[e.RowIndex].ReadOnly)
            {
                oDateTimePicker = dataGridChef.CreateDateTimePicker(e);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);
                oDateTimePicker.Leave += new EventHandler(oDateTimePicker_CloseUp);
                oDateTimePicker.LostFocus += new EventHandler(oDateTimePicker_CloseUp);
            }
            //If a datepicker or comboBox is already open, prompt the user to make a selection there first
            else if (e.RowIndex != -1 && dataGridChef.SelectedCell != null && !GrdEmployees.Rows[e.RowIndex].ReadOnly && ((comboBoxColumnIndices.Contains(e.ColumnIndex) || datePickerColumnIndices.Contains(e.ColumnIndex)) && (oComboBox != null && oComboBox.Visible == true) || (oDateTimePicker != null && oDateTimePicker.Visible == true)))
            {
                MessageBox.Show("There is already a ComboBox or DateTimePicker in column #" + dataGridChef.SelectedCell.ColumnIndex + " " + '"' + GrdEmployees.Columns[dataGridChef.SelectedCell.ColumnIndex].HeaderText + '"' + " open, please select a value there first.");
                GrdEmployees.CurrentCell = dataGridChef.SelectedCell;
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

                case 23:
                    comboBoxDataSource = Employee.CadreOptions.ConvertAll<string>(x => x.ToString());
                    break;
            }

            return comboBoxDataSource;
        }

        //Update comboBox or datePicker location when user is scrolling through dataGridView
        private void GrdEmployees_Scroll(object sender, ScrollEventArgs e)
        {
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
            CmdCreateEmployee.Enabled = false;
            CmdCreateTrainee.Enabled = false;
            CmdModifyEmployee.Enabled = false;
            CmdDeleteEmployee.Enabled = false;
            CmdSaveEmployee.Enabled = true;
            CmdCancel.Enabled = true;
        }

        ///<summary>
        ///Activates and deactives buttons and textfields for GUI "view mode"
        ///</summary>
        private void SetGUIToViewMode()
        {
            CmdCreateEmployee.Enabled = true;
            CmdCreateTrainee.Enabled = true;
            CmdModifyEmployee.Enabled = true;
            CmdDeleteEmployee.Enabled = true;
            CmdSaveEmployee.Enabled = false;
            CmdCancel.Enabled = false;
        }

        private void CmdVCardImport_Click(object sender, EventArgs e)
        {

        }

        private void CmdCSVImport_Click(object sender, EventArgs e)
        {

        }
    }
}

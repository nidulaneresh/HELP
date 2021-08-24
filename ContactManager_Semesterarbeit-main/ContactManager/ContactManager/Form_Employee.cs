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
    public partial class Form_Employee : Form
    {
        private ContactBook contactBook;
        private Form_Dashboard form_Dashboard;
        private DataGridChef dataGridChef;
        
        private DateTimePicker oDateTimePicker;
        private ComboBox oComboBox;

        private readonly List<int> comboBoxColumnIndices = new List<int>() { 1, 5, 8, 23 };
        private readonly List<int> datePickerColumnIndices = new List<int>() { 4, 19, 20};

        private readonly List<int> mandatoryFieldsEmployee = new List<int>() { 1, 2, 3, 4, 7, 8, 19,24,25};
        private List<int> mandatoryFieldsTrainee;

        private void defineMandatoryFieldsTrainee()
        {
            mandatoryFieldsTrainee = new List<int>(mandatoryFieldsEmployee);
            mandatoryFieldsTrainee.Add(24);
            mandatoryFieldsTrainee.Add(25);
        }

        public Form_Employee(ContactBook contactBook, Form_Dashboard frm_Dashboard)
        {
            InitializeComponent();
            this.contactBook = contactBook;
            this.form_Dashboard = frm_Dashboard;

            defineMandatoryFieldsTrainee();

            dataGridChef = new DataGridChef(GrdEmployees, comboBoxColumnIndices, datePickerColumnIndices);
        }

        private void Form_Employee_Load(object sender, EventArgs e)
        {
            PbBackToDashboard.Parent = pictureBox1;
            PbBackToDashboard.BackColor = Color.Transparent;

            LblDashboard.Parent = pictureBox1;
            LblDashboard.BackColor = Color.Transparent;

            LblHistory.Parent = pictureBox1;
            LblHistory.BackColor = Color.Transparent;

            GrdEmployees.DataSource = contactBook.EmployeeTable;
            dataGridChef.InitialTableDefinition();
        }

        // Anhand mit einem Klick auf Dashboard-Icon zurück zum Dashboard gelangen
        private void PbBackToDashboard_Click_1(object sender, EventArgs e)
        {
            form_Dashboard.Show();
            this.Close();
        }

        private void CmdCreateEmployee_Click(object sender, EventArgs e)
        {
            contactBook.EmployeeTable.Rows.Add();
            dataGridChef.FormatRowModifiable(dataGridChef.FindModifiableRow(), mandatoryFieldsEmployee);
            dataGridChef.LockTraineeFieldsForEmployee();
            contactBook.EmployeeCounter++;
            dataGridChef.FindModifiableRow().Cells[0].Value = contactBook.EmployeeCounter;

            // Button Deactivate
            CmdCreateEmployee.Enabled = false;
            CmdCreateTrainee.Enabled = false;
            CmdModifyEmployee.Enabled = false;
            CmdDeleteEmployee.Enabled = false;

            // Write in the History
            TxtHistory.Text += DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Employee No. " 
                + contactBook.EmployeeCounter + ": Added" + "\r\n";
        }

        private void CmdSaveEmployee_Click(object sender, EventArgs e)
        {
            int unlockedRowIndex = dataGridChef.FindModifiableRow().Index;

            //Checks if any of the rows is modifiable (-1 = all rows are read-only)
            if(unlockedRowIndex != -1)
            {
                //Kill datetimepicker or combobox
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

                Employee employee = Employee.createFromDataGridViewRow(GrdEmployees.Rows[unlockedRowIndex]);

                if (contactBook.Employees.ContainsKey(employee.EmployeeNumber))
                {
                    //Modify an existing employee
                    contactBook.Employees[employee.EmployeeNumber] = employee;
                    contactBook.History.UpdatedEmployee(contactBook.Employees[employee.EmployeeNumber], employee);
                }
                else
                {
                    //Create a new employee
                    contactBook.Employees.Add(employee.EmployeeNumber, employee);
                    contactBook.History.NewEmployee(employee);
                }

                dataGridChef.FormatRowReadOnly(dataGridChef.FindModifiableRow());
  
            }
            else
            {
                MessageBox.Show("all rows are read only, no need to save!");
            }

            CmdCreateEmployee.Enabled = true;
            CmdCreateTrainee.Enabled = true;
            CmdModifyEmployee.Enabled = true;
            CmdDeleteEmployee.Enabled = true;

        }

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

        private void GrdEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridChef.SelectedCell == null && comboBoxColumnIndices.Contains(e.ColumnIndex) && !GrdEmployees.Rows[e.RowIndex].ReadOnly)
            {
                oComboBox = dataGridChef.createComboBox(e, ChooseComboBoxDataSource(e.ColumnIndex));
                oComboBox.DropDownClosed += new EventHandler(oComboBox_CloseUp);
            }
            else if(dataGridChef.SelectedCell == null && datePickerColumnIndices.Contains(e.ColumnIndex) && !GrdEmployees.Rows[e.RowIndex].ReadOnly)
            {
                oDateTimePicker = dataGridChef.CreateDateTimePicker(e);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);
            }
        }

        
        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  

            if(dataGridChef.SelectedCell != null)
            {
                dataGridChef.SelectedCell.Value = oDateTimePicker.Text.ToString();
            }
            dataGridChef.SelectedCell = null;
        }     

        public void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use  
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            form_Dashboard.Show();
            base.OnFormClosing(e);
        }

        private void CmdTest_Click(object sender, EventArgs e)
        {
            contactBook.History.NewEmployee(contactBook.Employees[1]);
            contactBook.History.UpdatedEmployee(contactBook.Employees[2], contactBook.Employees[3]);
            contactBook.History.DeletedEmployee(contactBook.Employees[3]);

            foreach(string historyEntry in contactBook.History.EmployeeHistory)
            {
                TxtHistory.Text += historyEntry + "\r\n";
            }
        }

        private void CmdDeleteEmployee_Click(object sender, EventArgs e)
        {
            int index = GrdEmployees.CurrentCell.RowIndex;
            int employeeNumber = Convert.ToInt32(GrdEmployees.Rows[index].Cells[0].Value);

            string messageBoxText = "Do you really want to delete?";
            string caption = "Delete";
            MessageBoxButtons button = MessageBoxButtons.YesNoCancel;
            MessageBoxIcon icon = MessageBoxIcon.Warning;

            var result = MessageBox.Show(messageBoxText, caption, button, icon);

            if (result == DialogResult.Yes)
            {
                contactBook.Employees.Remove(employeeNumber);
                GrdEmployees.Rows.RemoveAt(index);
            }

            // Write in the History
            TxtHistory.Text += DateTime.Now.ToString("dd.MM.yyyy HH:mm") + 
                " - Employee No. " + employeeNumber + ": Deleted"+ "\r\n";

        }

        private void CmdModifyEmployee_Click(object sender, EventArgs e)
        {
            int index = GrdEmployees.CurrentCell.RowIndex;
            int employeeNumber = Convert.ToInt32(GrdEmployees.Rows[index].Cells[0].Value);

            if (IamATrainee())
            {
                dataGridChef.FormatRowModifiable(GrdEmployees.CurrentRow, mandatoryFieldsTrainee);
            }
            else
            {
                dataGridChef.FormatRowModifiable(GrdEmployees.CurrentRow, mandatoryFieldsEmployee);
            }
            GrdEmployees.ClearSelection();

            // Write in the History
            TxtHistory.Text += DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Employee No. "
                 + employeeNumber + ": Modify" + "\r\n";
            // Button Deactivate
            CmdCreateEmployee.Enabled = false;
            CmdCreateTrainee.Enabled = false;
            CmdModifyEmployee.Enabled = false;
            CmdDeleteEmployee.Enabled = false;
        }

        private bool IamATrainee()
        {
            int rowIndex = GrdEmployees.CurrentCell.RowIndex;
            int employeeNumber = Convert.ToInt32(GrdEmployees.Rows[rowIndex].Cells[0].Value);
            Employee employee = contactBook.Employees[employeeNumber];

            if (employee is Trainee)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CmdCreateTrainee_Click(object sender, EventArgs e)
        {
            //tODO: finish -> Add new Trainee
            contactBook.EmployeeTable.Rows.Add();
            dataGridChef.FormatRowModifiable(dataGridChef.FindModifiableRow(), mandatoryFieldsEmployee);
            contactBook.EmployeeCounter++;
            dataGridChef.FindModifiableRow().Cells[0].Value = contactBook.EmployeeCounter;
            
            // Button Deactivate
            CmdCreateEmployee.Enabled = false;
            CmdCreateTrainee.Enabled = false;
            CmdModifyEmployee.Enabled = false;
            CmdDeleteEmployee.Enabled = false;

            // Write in the History
            TxtHistory.Text += DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Employee No. "
                + contactBook.EmployeeCounter + ": Added" + "\r\n";
        }

        private void TxtSearchDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                
            }
        }

        private void TxtSearchDB_TextChanged(object sender, EventArgs e)
        {
            /*
            string searchValue = TxtSearchDB.Text;
            var re = from row in GrdEmployees.AsEnumerable()
                     where row[1].ToString().Contains(searchValue)
                     select row;
            */
        }
    }
}

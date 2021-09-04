using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    class DataGridChef
    {
        private DataGridView MyDataGridView { get; set; }
        private List<int> ComboBoxColumnIndices { get; set; }
        private List<int> DatePickerColumnIndices { get; set; }

        //Define colors used in all dataGridViews
        private static readonly Color readOnlyFieldColor = Color.LightGray;
        private static readonly Color mandatoryFieldColor = Color.Thistle;
        private static readonly Color modifiableFieldColor = Color.White;

        //the currently selected cell in the grid, used for datepicker and comboBox
        public DataGridViewCell SelectedCell { get; set; }

        //Initiate dataGridChef with some information upfront to not always need to pass everything
        public DataGridChef(DataGridView dataGridView, List<int> comboBoxColumnIndices, List<int> datePickerColumnIndices)
        {
            MyDataGridView = dataGridView;
            ComboBoxColumnIndices = comboBoxColumnIndices;
            DatePickerColumnIndices = datePickerColumnIndices;
        }

        ///<summary>
        ///Initial Definition of the tables, set all to read-only and set corresponding colors
        ///</summary>
        public void InitialTableDefinition()
        {
            MyDataGridView.DefaultCellStyle.BackColor = readOnlyFieldColor;

            for (int i = 0; i < MyDataGridView.Rows.Count; i++)
            {
                MyDataGridView.Rows[i].ReadOnly = true;
                MyDataGridView.Rows[i].DefaultCellStyle.BackColor = readOnlyFieldColor;
            }

            MyDataGridView.AllowUserToAddRows = false;
            PreventSortingOfAllColumns();
        }

        ///<summary>
        ///Returns the row that is currently unlocked
        ///</summary>
        public DataGridViewRow FindModifiableRow()
        {
            DataGridViewRow modifiableDataGridViewRow = new DataGridViewRow();

            //Find the row that is not read-only
            for (int i = 0; i < MyDataGridView.Rows.Count; i++)
            {
                if (!MyDataGridView.Rows[i].ReadOnly)
                {
                    modifiableDataGridViewRow = MyDataGridView.Rows[i];
                    break;
                }
            }
            return modifiableDataGridViewRow;
        }

        ///<summary>
        ///Formats a row to be read-only (settting of colors, read-only states)
        ///</summary>
        public void FormatRowReadOnly(DataGridViewRow dataGridViewRow)
        {
            dataGridViewRow.ReadOnly = true;
            
            //Set all cells to read-only Color
            for(int i = 0; i < dataGridViewRow.Cells.Count; i++)
            {
                dataGridViewRow.Cells[i].Style.BackColor = readOnlyFieldColor;
            }
        }

        ///<summary>
        ///Formats a row to be in modify state (settting of colors, highlight mandatory fields, read-only states of comboBox and datepicker cells)
        ///</summary>
        public void FormatRowModifiable(DataGridViewRow dataGridViewRow, List<int> mandatoryFieldIndices)
        {
            dataGridViewRow.ReadOnly = false;

            //Set all cells to modify Color
            for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
            {
                dataGridViewRow.Cells[i].Style.BackColor = modifiableFieldColor;
            }

            //Set mandatory field color
            for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
            {
                if (mandatoryFieldIndices.Contains(i))
                {
                    dataGridViewRow.Cells[i].Style.BackColor = mandatoryFieldColor;
                }
            }

            //Set all fields that are to be filled with a datepicker to read-only
            for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
            {
                if (DatePickerColumnIndices.Contains(i))
                {
                    dataGridViewRow.Cells[i].ReadOnly = true;
                }                
            }

            //Set all fields that are to be filled with a combobox to read-only
            for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
            {
                if (ComboBoxColumnIndices.Contains(i))
                {
                    dataGridViewRow.Cells[i].ReadOnly = true;
                }
            }

            //Set employeeNumber field back to read-only
            dataGridViewRow.Cells[0].ReadOnly = true;
            dataGridViewRow.Cells[0].Style.BackColor = readOnlyFieldColor;
        }

        ///<summary>
        ///Creates a comboBox at the currently selected cell location with the options passed to the method
        ///</summary>
        public ComboBox createComboBox(DataGridViewCellEventArgs e, List<string> comboBoxDataSource)
        {
            ComboBox oComboBox = new ComboBox();

            //Remember the selectedCell
            SelectedCell = MyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            //Define combobox, link to dataGridView 
            oComboBox.DataSource = comboBoxDataSource;
            MyDataGridView.Controls.Add(oComboBox);

            //Setting size and location
            Rectangle oRectangle = MyDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            oComboBox.Size = new Size(oRectangle.Width, oRectangle.Height);
            oComboBox.Location = new Point(oRectangle.X, oRectangle.Y);

            // Now make it visible  
            oComboBox.Visible = true;                

            return oComboBox;
        }

        ///<summary>
        ///Creates a datetimepicker at the currently selected cell location
        ///</summary>
        public DateTimePicker CreateDateTimePicker(DataGridViewCellEventArgs e)
        {
            DateTimePicker oDateTimePicker = new DateTimePicker();

            //Remember the selectedCell
            SelectedCell = MyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            //If there is already a value in the cell, set the datepicker to this date
            if(SelectedCell.Value.ToString() != String.Empty)
            {
                string date = MyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string[] splitDate = date.Split('.');
                splitDate[2] = splitDate[2].Remove(4, 9);

                DateTime convertedDate = new DateTime(Convert.ToInt32(splitDate[2]), Convert.ToInt32(splitDate[1]), Convert.ToInt32(splitDate[0]));

                if(convertedDate != new DateTime(01,01,0001, 00,00,00))
                oDateTimePicker.Value = convertedDate;
            }

            //Define combobox, link to dataGridView 
            MyDataGridView.Controls.Add(oDateTimePicker);

            //Setting format, size and location
            oDateTimePicker.Format = DateTimePickerFormat.Short;
            Rectangle oRectangle = MyDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
            oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

            // Now make it visible  
            oDateTimePicker.Visible = true;

            return oDateTimePicker;
        }

        ///<summary>
        ///Lock Trainee fields for employee (useful when in modify mode)
        ///</summary>
        public void LockTraineeFieldsForEmployee()
        {
            FindModifiableRow().Cells[24].ReadOnly = true;
            FindModifiableRow().Cells[25].ReadOnly = true;

            FindModifiableRow().Cells[24].Style.BackColor = readOnlyFieldColor;
            FindModifiableRow().Cells[25].Style.BackColor = readOnlyFieldColor;
        }

        ///<summary>
        ///Check if all mandatory fields are filled based on the list passed to the method
        ///</summary>
        public bool AllMandatoryFieldsFilled(List <int> mandatoryFields)
        {
            DataGridViewRow modifiedRow = FindModifiableRow();
            bool allMandatoryFieldsFilled = false;

            foreach(int mandatoryFieldColumnIndex in mandatoryFields)
            {
                if(modifiedRow.Cells[mandatoryFieldColumnIndex].Value.ToString() == String.Empty)
                {
                    allMandatoryFieldsFilled = false;
                    break;
                }
                else
                {
                    allMandatoryFieldsFilled = true;
                }
            }

            return allMandatoryFieldsFilled;
        }

        ///<summary>
        ///Update position of any control based on selected cell
        ///</summary>
        public void UpdateControlPosition(Control control)
        {
            //Datepicker and ComboBox are both derived from control -> can use method for both
            Rectangle oRectangle = MyDataGridView.GetCellDisplayRectangle(SelectedCell.ColumnIndex, SelectedCell.RowIndex, true);
            control.Size = new Size(oRectangle.Width, oRectangle.Height);
            control.Location = new Point(oRectangle.X, oRectangle.Y);
        }

        ///<summary>
        ///Prevent the user from sorting any of the columns
        ///</summary>
        public void PreventSortingOfAllColumns()
        {
            foreach(DataGridViewColumn column in MyDataGridView.Columns)
            {               
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}

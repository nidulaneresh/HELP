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

        private ContactBook contactBook;

        private static readonly Color readOnlyFieldColor = Color.LightGray;
        private static readonly Color mandatoryFieldColor = Color.LightYellow;
        private static readonly Color modifiableFieldColor = Color.White;

        public DataGridViewCell SelectedCell { get; set; }

        public DataGridChef(DataGridView dataGridView, List<int> comboBoxColumnIndices, List<int> datePickerColumnIndices)
        {
            MyDataGridView = dataGridView;
            ComboBoxColumnIndices = comboBoxColumnIndices;
            DatePickerColumnIndices = datePickerColumnIndices;

            contactBook = new ContactBook();
        }

        public void InitialTableDefinition()
        {
            for (int i = 0; i < MyDataGridView.Rows.Count; i++)
            {
                MyDataGridView.Rows[i].ReadOnly = true;
                MyDataGridView.Rows[i].DefaultCellStyle.BackColor = readOnlyFieldColor;
            }

            MyDataGridView.AllowUserToAddRows = false;
        }
        
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

        public void FormatRowReadOnly(DataGridViewRow dataGridViewRow)
        {
            dataGridViewRow.ReadOnly = true;
            
            //Set all cells to read-only Color
            for(int i = 0; i < dataGridViewRow.Cells.Count; i++)
            {
                dataGridViewRow.Cells[i].Style.BackColor = readOnlyFieldColor;
            }
        }

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
                    //TODO: Pflichtfeld müssen ausgefüllt werden
                    //message box
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

        public void LockTraineeFieldsForEmployee()
        {
            FindModifiableRow().Cells[24].ReadOnly = true;
            FindModifiableRow().Cells[25].ReadOnly = true;

            FindModifiableRow().Cells[24].Style.BackColor = readOnlyFieldColor;
            FindModifiableRow().Cells[25].Style.BackColor = readOnlyFieldColor;
        }
    }
}

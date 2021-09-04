using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    public class ContactDoc
    {
        //Properties
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Datum { get; set; }
        public string Notes { get; set; }

        public ContactDoc(int id, int customerId, int employeeId, string notes, DateTime datum)
        {
            Id = id;
            CustomerId = customerId;
            EmployeeId = employeeId;
            Notes = notes;
            Datum = datum;
        }

        ///<summary>
        ///Create a DataRow based on ContactDoc Properties. Links customers and employees from other Dictionaries based on ID
        ///</summary>
        public DataRow GetDataRow(DataTable table, ContactBook contactBook)
        {
            DataRow row = table.NewRow();

            row[0] = this.Id;

            string customerString = contactBook.Customers[this.CustomerId].CustomerNumber + "| " + contactBook.Customers[this.CustomerId].Vorname + " " + contactBook.Customers[this.CustomerId].Nachname;
            row[1] = customerString;

            string employeeString = contactBook.Employees[this.EmployeeId].EmployeeNumber + "| " + contactBook.Employees[this.EmployeeId].Vorname + " " + contactBook.Employees[this.EmployeeId].Nachname;
            row[2] = employeeString;

            row[3] = this.Datum;
            row[4] = this.Notes;

            return row;
        }

        ///<summary>
        ///Compares two ContactDocs and returns all differences collected as a string
        ///</summary>
        public static string Compare(ContactDoc thisContactDoc, ContactDoc otherContactDoc)
        {
            PropertyInfo[] thisProperties = thisContactDoc.GetType().GetProperties();
            string differences = "";

            //this if makes sure that you compare only objects of the same type (comparing Customers and Employees is not possible)
            if (thisContactDoc.GetType() == otherContactDoc.GetType())
            {
                //Iterates through all properties
                for (int i = 0; i < thisProperties.Length; i++)
                {
                    //If properties are different, returns string with differences
                    if (Convert.ToString(thisProperties[i].GetValue(thisContactDoc)) != Convert.ToString(thisProperties[i].GetValue(otherContactDoc)))
                    {
                        differences += thisProperties[i].Name + " changed from " + '"' + thisProperties[i].GetValue(thisContactDoc) + '"' + " to " + '"' + thisProperties[i].GetValue(otherContactDoc) + '"';

                        //Removes "," on last entry 
                        if (i < thisProperties.Length - 1)
                        {
                            differences += ", ";
                        }
                    }
                }
            }

            return differences;
        }

        ///<summary>
        ///creates a ContactDoc based on a DataGridViewRow coming from ContactDocTable
        ///</summary>
        public static ContactDoc CreateFromDataGridViewRow(DataGridViewRow contactDocRow, ContactBook contactBook)
        {
            int id = Convert.ToInt32(contactDocRow.Cells[0].Value.ToString());
            string notes = contactDocRow.Cells[4].Value.ToString();

            DateTime datum = Convert.ToDateTime(contactDocRow.Cells[3].Value.ToString());

            int customerId = FindIdInComboBoxText(contactDocRow.Cells[1].Value.ToString());

            int employeeId = FindIdInComboBoxText(contactDocRow.Cells[2].Value.ToString());

            ContactDoc contactDoc = new ContactDoc(id, customerId, employeeId, notes, datum);

            return contactDoc;
        }

        ///<summary>
        ///Separates ID from ComboBoxText (ID| Firstname Lastname) -> ID as INT
        ///</summary>
        private static int FindIdInComboBoxText(string comboBoxText)
        {
            int id;

            string[] splitEmployeeComboBoxText = comboBoxText.Split('|');
            id = Convert.ToInt32(splitEmployeeComboBoxText[0]);

            return id;
        }

    }
}

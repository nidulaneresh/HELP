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
    public class Customer : Person
    {
        public int CustomerNumber { get; set; } //Pflicht
        public string FirmenName { get; set; } //Pflicht
        public string BusinessAddress { get; set; }
        public string KundenTyp { get; set; } // A-E
        public string Kundenkontakt { get; set; }

        //CustomerType Options for ComboBox
        public static readonly List<string> CustomerTypeOptions = new List<string>() { "A", "B", "C", "D", "E" };

        public Customer(int customerNumber) : base()
        {
            CustomerNumber = customerNumber;
        }

        ///<summary>
        ///returns a DataRow of the Persons information that can be used for the DataTable
        ///</summary>
        public override DataRow GetDataRow(DataTable table)
        {
            DataRow row = table.NewRow();

            row[0] = this.CustomerNumber;
            row[1] = this.Anrede;
            row[2] = this.Vorname;
            row[3] = this.Nachname;
            row[4] = this.Birthday; 
            row[5] = this.Geschlecht;
            row[6] = this.MobilNummer;
            row[7] = this.Email;
            row[8] = this.Status;
            row[9] = this.AHVnummer;
            row[10] = this.Wohnort;
            row[11] = this.Nationality;
            row[12] = this.Adresse;
            row[13] = this.Postleitzahl;
            row[14] = this.TelefonnummerPrivat;
            row[15] = this.FirmenName;
            row[16] = this.BusinessAddress;
            row[17] = this.KundenTyp;
            row[18] = this.Kundenkontakt;

            return row;
        }

        ///<summary>
        ///returns all properties collected as a string. Useful for debugging
        ///</summary>
        public override string GetDataAsString()
        {
            return base.GetDataAsString() + ", " + CustomerNumber + ", " + FirmenName + ", " + BusinessAddress
                + ", " + KundenTyp + ", " + Kundenkontakt;
        }

        ///<summary>
        ///Create Customer based on a DataGridViewRow
        ///</summary>
        public static Customer CreateFromDataGridViewRow(DataGridViewRow CustomerRow)
        {
            int customerNumber = Convert.ToInt32(CustomerRow.Cells[0].Value.ToString());
            string salutation = CustomerRow.Cells[1].Value.ToString();
            string firstname = CustomerRow.Cells[2].Value.ToString();
            string lastname = CustomerRow.Cells[3].Value.ToString();
            string gender = CustomerRow.Cells[5].Value.ToString();
            string mobilNumber = CustomerRow.Cells[6].Value.ToString();
            string email = CustomerRow.Cells[7].Value.ToString();
            string status = CustomerRow.Cells[8].Value.ToString();
            string ahvNumber = CustomerRow.Cells[9].Value.ToString();
            string location = CustomerRow.Cells[10].Value.ToString();
            string nationality = CustomerRow.Cells[11].Value.ToString();
            string address = CustomerRow.Cells[12].Value.ToString();
            string zipCode = CustomerRow.Cells[13].Value.ToString();
            string phoneNumberPrivat = CustomerRow.Cells[14].Value.ToString();
            string companyName = CustomerRow.Cells[15].Value.ToString();
            string businessAddress = CustomerRow.Cells[16].Value.ToString();
            string customerTyp = CustomerRow.Cells[17].Value.ToString();
            string customerContact = CustomerRow.Cells[18].Value.ToString();


            Customer customer = new Customer(customerNumber)
            {
                Anrede = salutation,
                Vorname = firstname,
                Nachname = lastname,
                Geschlecht = gender,
                MobilNummer = mobilNumber,
                Email = email,
                Status = status,
                AHVnummer = ahvNumber,
                Wohnort = location,
                Nationality = nationality,
                Adresse = address,
                Postleitzahl = zipCode,
                TelefonnummerPrivat = phoneNumberPrivat,
                FirmenName = companyName,
                BusinessAddress = businessAddress,
                KundenTyp = customerTyp,
                Kundenkontakt = customerContact,
            };

            if (CustomerRow.Cells[4].Value.ToString() != "")
            {
                customer.Birthday = Convert.ToDateTime(CustomerRow.Cells[4].Value.ToString());
            }

            return customer;
        }

        ///<summary>
        ///Converts all available Customers into Id| Firstname Lastname string for ContactDocComboBox
        ///</summary>
        public static List<string> ContactDocOptions(Dictionary<int, Customer> customerDictionary)
        {
            List<string> contactDocCustomerOptions = new List<string>();

            foreach (KeyValuePair<int, Customer> customer in customerDictionary)
            {
                string text = customer.Key + "| " + customer.Value.Vorname + " " + customer.Value.Nachname;
                contactDocCustomerOptions.Add(text);
            }

            if (contactDocCustomerOptions.Count == 0)
            {
                contactDocCustomerOptions.Add("Customer list is empty");
            }

            return contactDocCustomerOptions;
        }
    }
}

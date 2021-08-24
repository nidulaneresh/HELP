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
    public class Employee : Person
    {
        public string Titel { get; set; }
        public string TelNrGes { get; set; }  // TelefonNummer //Pflicht
        public string FaxNr { get; set; } //FaxNummer 
        public int EmployeeNumber { get; set; } //Pflicht
        public string Abteilung { get; set; }
        public DateTime Eintrittsdatum { get; set; } //Pflicht
        public DateTime Austrittsdatum { get; set; }
        public string EmployementLevel { get; set; } //Pflicht
        public string Rolle { get; set; }  //Tätigkeitsbezeichnung
        public int Kaderstufe { get; set; }   // 0-5

        public static readonly List<int> CadreOptions = new List<int>() { 0, 1, 2, 3, 4, 5 };

        [Newtonsoft.Json.JsonConstructor]
        public Employee(int employeeNumber) : base()
        {
            EmployeeNumber = employeeNumber;
        }

        //only used for test data, to be deleted
        public Employee(string anrede, string vorname, string nachname, string email, DateTime birthday,    //Pflicht Person
            int employeenumber, DateTime eintritt, DateTime austritt, string employementLevel,              //Pflicht Employee

            string geschlecht = "", string mobilNummer = "", string status = "", string ahvnummer = "",     //Optional Person
            string wohnort = "", string nationality = "", string adresse = "", string postleitzahl = "",    //Optional Person
            string telnrprivat = "",                                                                        //Optional Person

            string titel = "", string telNrGes = "", string faxNr = "", string abteilung = "",              //Optional Employee
            string rolle = "", int kaderstufe = 0)                                                          //Optional Employee

            : base(anrede, vorname, nachname, email, birthday, geschlecht, mobilNummer, status, ahvnummer,
                wohnort, nationality, adresse, postleitzahl, telnrprivat)
        {
            Titel = titel;
            TelNrGes = telNrGes;
            FaxNr = faxNr;
            EmployeeNumber = employeenumber;
            Abteilung = abteilung;
            Eintrittsdatum = eintritt;
            Austrittsdatum = austritt;
            EmployementLevel = employementLevel;
            Rolle = rolle;
            Kaderstufe = kaderstufe;
        }

        //returns a DataRow of the Persons information that can be used for the DataTable
        public override DataRow GetDataRow(DataTable table)
        {
            DataRow row = table.NewRow();

            row[0] = this.EmployeeNumber;
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
            row[15] = this.TelNrGes;
            row[16] = this.FaxNr;
            row[17] = this.Titel;
            row[18] = this.Abteilung;
            row[19] = this.Eintrittsdatum;
            row[20] = this.Austrittsdatum;
            row[21] = this.EmployementLevel;
            row[22] = this.Rolle;
            row[23] = this.Kaderstufe;

            return row;
        }

        //Updating information saved in the object
        public override void Update()
        {
            //need to add specific code
            base.Update();
        }

        //Check if two persons are exactly the same, returns a bool
        public override bool Equal(Person otherPerson)
        {
            //need to add specific code
            return base.Equal(otherPerson);
        }

        public override string GetDataAsString()
        {
            return base.GetDataAsString() + ", " + Titel + ", " + TelNrGes + ", " + FaxNr + ", " + EmployeeNumber + ", " + Abteilung
                 + ", " + Eintrittsdatum + ", " + Austrittsdatum + ", " + EmployementLevel + ", " + Rolle + ", " + Kaderstufe;

        }

        ///<summary>
        ///creates an Employee based on a DataGridViewRow coming from EmployeeTable
        ///</summary>
        public static Employee createFromDataGridViewRow(DataGridViewRow employeeRow)
        {
            int employeeNumber = Convert.ToInt32(employeeRow.Cells[0].Value.ToString());
            string salutation = employeeRow.Cells[1].Value.ToString();
            string firstname = employeeRow.Cells[2].Value.ToString();
            string lastname = employeeRow.Cells[3].Value.ToString();
            string email = employeeRow.Cells[7].Value.ToString();
            string employementLevel = employeeRow.Cells[21].Value.ToString();

            Employee employee = new Employee(employeeNumber)
            {
                Anrede = salutation,
                Vorname = firstname,
                Nachname = lastname,
                Email = email,
                EmployementLevel = employementLevel
            };

            if (employeeRow.Cells[4].Value.ToString() != "")
            {
                employee.Birthday = Convert.ToDateTime(employeeRow.Cells[4].Value.ToString());
            }
            if (employeeRow.Cells[19].Value.ToString() != "")
            {
                employee.Eintrittsdatum = Convert.ToDateTime(employeeRow.Cells[19].Value.ToString());
            }
            if (employeeRow.Cells[20].Value.ToString() != "")
            {
                employee.Austrittsdatum = Convert.ToDateTime(employeeRow.Cells[20].Value.ToString());
            }

            return employee;
        }

    }
}

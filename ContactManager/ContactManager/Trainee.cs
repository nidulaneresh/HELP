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
    public class Trainee : Employee
    {
        public int MaxTraineeYears { get; set; } //Pflicht
        public int CurrentTraineeYear { get; set; } //Pflicht

        public Trainee(int employeeNumber) : base(employeeNumber)
        {

        }

        //only used to fix JSON import
        public Trainee(Employee employee) : base(employee.EmployeeNumber)
        {
            Anrede = employee.Anrede;
            Vorname = employee.Vorname;
            Nachname = employee.Nachname;
            Email = employee.Email;
            Birthday = employee.Birthday;
            Geschlecht = employee.Geschlecht;
            MobilNummer = employee.MobilNummer;
            Status = employee.Status;
            AHVnummer = employee.AHVnummer;
            Wohnort = employee.Wohnort;
            Nationality = employee.Nationality;
            Adresse = employee.Adresse;
            Postleitzahl = employee.Postleitzahl;
            TelefonnummerPrivat = employee.TelefonnummerPrivat;
            Titel = employee.Titel;
            TelNrGes = employee.TelNrGes;
            FaxNr = employee.FaxNr;
            Abteilung = employee.Abteilung;
            Eintrittsdatum = employee.Eintrittsdatum;
            Austrittsdatum = employee.Austrittsdatum;
            EmployementLevel = employee.EmployementLevel;
            Rolle = employee.Rolle;
            Kaderstufe = employee.Kaderstufe;
        }

        ///<summary>
        ///returns a DataRow of the Persons information that can be used for the DataTable
        ///</summary>
        public DataRow TraineeGetDataRow(DataTable table)
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
            row[24] = this.MaxTraineeYears;
            row[25] = this.CurrentTraineeYear;

            return row;
        }

        ///<summary>
        ///creates a Trainee based on a DataGridViewRow coming from EmployeeTable
        ///</summary>
        public static new Trainee CreateFromDataGridViewRow(DataGridViewRow employeeRow)
        {
            int employeeNumber = Convert.ToInt32(employeeRow.Cells[0].Value.ToString());
            string salutation = employeeRow.Cells[1].Value.ToString();
            string firstname = employeeRow.Cells[2].Value.ToString();
            string lastname = employeeRow.Cells[3].Value.ToString();
            string gender = employeeRow.Cells[5].Value.ToString();
            string mobilNumber = employeeRow.Cells[6].Value.ToString();
            string email = employeeRow.Cells[7].Value.ToString();
            string status = employeeRow.Cells[8].Value.ToString();
            string ahvNumber = employeeRow.Cells[9].Value.ToString();
            string location = employeeRow.Cells[10].Value.ToString();
            string nationality = employeeRow.Cells[11].Value.ToString();
            string address = employeeRow.Cells[12].Value.ToString();
            string zipCode = employeeRow.Cells[13].Value.ToString();
            string phoneNumberPrivat = employeeRow.Cells[14].Value.ToString();
            string phoneNumberBusiness = employeeRow.Cells[15].Value.ToString();
            string faxNumber = employeeRow.Cells[16].Value.ToString();
            string titel = employeeRow.Cells[17].Value.ToString();
            string division = employeeRow.Cells[18].Value.ToString();
            string employementLevel = employeeRow.Cells[21].Value.ToString();
            string role = employeeRow.Cells[22].Value.ToString();
            int cadreLevel = 0;
            int maxTraineeYears = Convert.ToInt32(employeeRow.Cells[24].Value.ToString());
            int currentTraineeYear = Convert.ToInt32(employeeRow.Cells[25].Value.ToString());

            if (employeeRow.Cells[23].Value.ToString() != String.Empty)
            {
                cadreLevel = Convert.ToInt32(employeeRow.Cells[23].Value.ToString());
            }


            Trainee trainee = new Trainee(employeeNumber)
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
                TelNrGes = phoneNumberBusiness,
                FaxNr = faxNumber,
                Titel = titel,
                Abteilung = division,
                EmployementLevel = employementLevel,
                Rolle = role,
                Kaderstufe = cadreLevel,
                MaxTraineeYears = maxTraineeYears,
                CurrentTraineeYear = currentTraineeYear                
            };

            if (employeeRow.Cells[4].Value.ToString() != "")
            {
                trainee.Birthday = Convert.ToDateTime(employeeRow.Cells[4].Value.ToString());
            }
            if (employeeRow.Cells[19].Value.ToString() != "")
            {
                trainee.Eintrittsdatum = Convert.ToDateTime(employeeRow.Cells[19].Value.ToString());
            }
            if (employeeRow.Cells[20].Value.ToString() != "")
            {
                trainee.Austrittsdatum = Convert.ToDateTime(employeeRow.Cells[20].Value.ToString());
            }

            return trainee;
        }

        ///<summary>
        ///Returns all properties as string. Useful for debugging.
        ///</summary>
        public override string GetDataAsString()
        {
            return base.GetDataAsString() + ", " + MaxTraineeYears + ", " +
                CurrentTraineeYear;
        }
    }
}

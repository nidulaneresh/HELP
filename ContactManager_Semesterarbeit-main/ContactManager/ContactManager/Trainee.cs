using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Trainee : Employee
    {
        public int MaxTraineeYears { get; set; } //Pflicht
        public int CurrentTraineeYear { get; set; } //Pflicht

        public Trainee(string anrede, string vorname, string nachname, string email, DateTime birthday,      //Pflicht Person
            int employeenumber, DateTime eintritt, DateTime austritt, string employementLevel,              //Pflicht Employee
            int maxTraineeYears, int currentTraineeYear,                                                    //Pflicht Trainee

            string geschlecht = "", string mobilNummer = "", string status = "", string ahvnummer = "",     //Optional Person
            string wohnort = "", string nationality = "", string adresse = "", string postleitzahl = "",    //Optional Person
            string telnrprivat = "",                                                                        //Optional Person

            string titel = "", string telNrGes = "", string faxNr = "", string abteilung = "",              //Optional Employee
            string rolle = "", int kaderstufe = 0)                                                          //Optional Employee

            : base(anrede, vorname, nachname, email, birthday, employeenumber, eintritt, austritt, employementLevel, geschlecht, mobilNummer, status, ahvnummer,
                  wohnort, nationality, adresse, postleitzahl, telnrprivat, titel, telNrGes, faxNr, abteilung,
                  rolle, kaderstufe)
        {
            MaxTraineeYears = maxTraineeYears;
            CurrentTraineeYear = currentTraineeYear;
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
            row[24] = this.MaxTraineeYears;
            row[25] = this.CurrentTraineeYear;

            return base.GetDataRow(table);
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
            return base.GetDataAsString() + ", " + MaxTraineeYears + ", " +
                CurrentTraineeYear;
        }

        public void IncreaseTraineeYear()
        {
            if (CurrentTraineeYear < MaxTraineeYears)
                CurrentTraineeYear++;
        }
    }
}

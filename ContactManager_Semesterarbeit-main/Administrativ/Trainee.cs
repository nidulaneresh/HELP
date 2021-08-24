using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vererbung
{
    class Trainee : Employee
    {
        public int MaxTraineeYears { get; set; }

        public int CurrentTraineeYear { get; set; }

        /*public Trainee (string firstname, string lastname, int employeeNumber,
            DateTime birthday, int maxTraineeYear, int currentTraineeYear) 
            : base(firstname, lastname, employeeNumber, birthday)*/

        public Trainee (string anrede, string vorname, string nachname,
            DateTime birthday, string geschlecht, int mobilNummer,
            string email, string status, int ahvnummer,
            string wohnort, string nationalität, string adresse,
            int postleitzahl, int telnrprivat,

            string titel, int telNrGes, int faxNr, int employeenumber, string
            abteilung, DateTime eintritt, DateTime austritt, string beschäftigungsgrad, string rolle, int kaderstufe,

             int maxTraineeYear, int currentTraineeYear

            ) : base(anrede, vorname, nachname, birthday, geschlecht, mobilNummer, email, status, ahvnummer,
                wohnort, nationalität, adresse, postleitzahl, telnrprivat, titel,telNrGes, faxNr,employeenumber,abteilung,
                eintritt, austritt,beschäftigungsgrad, rolle, kaderstufe)
        {
            MaxTraineeYears = maxTraineeYear;
            CurrentTraineeYear = currentTraineeYear;
        }

        public override string GetData()
        {
            return base.GetData() + ", " + MaxTraineeYears + ", " + 
                CurrentTraineeYear;
        }

        public void IncreaseTraineeYear()
        {
            if (CurrentTraineeYear < MaxTraineeYears)
                CurrentTraineeYear++;
        }
    }
}

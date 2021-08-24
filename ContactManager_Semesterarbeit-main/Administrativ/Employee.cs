using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vererbung
{
    class Employee : Person
    {
        public string Titel { get; set; }
        public int TelNrGes { get; set; }  // TelefonNummer
        public int FaxNr { get; set; } //FaxNummer 
        public int EmployeeNumber { get; set; }
        public string Abteilung { get; set; }
        public DateTime Eintrittsdatum { get; set; }
        public DateTime Austrittadatum { get; set; }
        public string Beschäftigungsgrad { get; set; }
        public string Rolle { get; set; }  //Tätigkeitsbezeichnung
        public int Kaderstufe { get; set; }   // 0-5


        public static int EmployeeCounter { get; private set; }

        public Employee(string anrede, string vorname, string nachname,
            DateTime birthday, string geschlecht, int mobilNummer,
            string email, string status, int ahvnummer,
            string wohnort, string nationalität, string adresse,
            int postleitzahl, int telnrprivat,

            string titel, int telNrGes, int faxNr, int employeenumber, string
            abteilung, DateTime eintritt, DateTime austritt, string beschäftigungsgrad, string rolle, int kaderstufe

            ) : base (anrede, vorname, nachname, birthday,geschlecht,mobilNummer,email,status,ahvnummer,
                wohnort,nationalität,adresse,postleitzahl,telnrprivat)
        {
            Titel = titel;
            TelNrGes = telNrGes;
            FaxNr = faxNr;
            EmployeeNumber = employeenumber;
            Abteilung = abteilung;
            Eintrittsdatum = eintritt;
            Austrittadatum = austritt;
            Beschäftigungsgrad = beschäftigungsgrad;
            Rolle = rolle;
            Kaderstufe = kaderstufe;
                        
            EmployeeCounter++;
        }

        public override string  GetData()
        {
            return base.GetData() + ", " + Titel + ", " + TelNrGes + ", " + FaxNr + ", " + EmployeeNumber + ", " + Abteilung
                 + ", " + Eintrittsdatum + ", " + Austrittadatum + ", " + Beschäftigungsgrad + ", " + Rolle + ", " + Kaderstufe;
               
        }


    }
}

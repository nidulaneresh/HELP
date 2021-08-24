using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vererbung
{
    class Person
    {
        public string Anrede { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Birthday { get; set; }
        public string Geschlecht { get; set; }


        public int MobilNummer { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }


        public int AHVnummer{ get; set; }
        public string Wohnort { get; set; }
        public string Nationalität { get; set; }
        public string Adresse { get; set; }
        public int Postleitzahl { get; set; }
        public int TelefonnummerPrivat { get; set; }




        public Person(string anrede, string vorname, string nachname,
            DateTime birthday, string geschlecht, int mobilNummer, 
            string email,string status,int ahvnummer, 
            string wohnort, string nationalität, string adresse, 
            int postleitzahl, int telnrprivat)
        {
            Anrede = anrede;
            Vorname = vorname;
            Nachname = nachname;
            Birthday = birthday;
            Geschlecht = geschlecht;

            MobilNummer = mobilNummer;
            Email = email;
            Status = status;

            AHVnummer = ahvnummer;
            Wohnort = wohnort;
            Nationalität = nationalität;
            Adresse = adresse;
            Postleitzahl = postleitzahl;
            TelefonnummerPrivat = telnrprivat;

        }


        public string GetData()
        {
            return Anrede + ", " + Vorname + ", " + Nachname + ", " + Birthday + ", "
                + Geschlecht + ", " + MobilNummer + ", " + Email + ", " + Status + ", "
                + AHVnummer + ", " + Wohnort+ ", "+ Nationalität+ ", "+ Adresse+ ", "+
                Postleitzahl+ ", "+TelefonnummerPrivat;
        }
    }
}

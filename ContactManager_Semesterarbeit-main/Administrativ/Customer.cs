using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vererbung
{
    class Customer : Person
    {
        public int CustomerNumber { get; set; }
        public string FirmenName { get; set; }
        public string Geschäftsadresse { get; set; }
        public string KundenTyp { get; set; } // A-E
        public string Kundenkontakt { get; set; }




        public Customer(string anrede, string vorname, string nachname,
            DateTime birthday, string geschlecht, int mobilNummer,
            string email, string status, int ahvnummer,
            string wohnort, string nationalität, string adresse,
            int postleitzahl, int telnrprivat,
            int customerNumber, string firmenName, string geschäftsadresse, string kundenTyp, string kundenKontakt
            ) :  base (anrede, vorname, nachname, birthday, geschlecht, mobilNummer, email, status, ahvnummer,
                wohnort, nationalität, adresse, postleitzahl, telnrprivat)
        {
            CustomerNumber = customerNumber;
            FirmenName = firmenName;
            Geschäftsadresse = geschäftsadresse;
            KundenTyp = kundenTyp;
            Kundenkontakt = kundenKontakt;
        }

        // Das ist eine Methiden Überschreibung!!!!
        public override string GetData()
        {
            return base.GetData() + ", " + CustomerNumber + ", " + FirmenName + ", " +Geschäftsadresse 
                + ", " +KundenTyp + ", " +Kundenkontakt;
        }


    }
}

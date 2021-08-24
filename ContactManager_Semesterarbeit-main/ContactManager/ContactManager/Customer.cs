using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Customer : Person
    {
        public int CustomerNumber { get; set; } //Pflicht
        public string FirmenName { get; set; } //Pflicht
        public string BusinessAddress { get; set; }
        public string KundenTyp { get; set; } // A-E
        public string Kundenkontakt { get; set; }

        public static readonly List<string> CustomerTypeOptions = new List<string>() { "A", "B", "C", "D", "E" };

        [Newtonsoft.Json.JsonConstructor]
        public Customer(int customerNumber) : base()
        {
            CustomerNumber = customerNumber;
        }

        //only used for test data, to be deleted
        public Customer(string anrede, string vorname, string nachname, string email, DateTime birthday, //Pflicht Person
            int customerNumber, string firmenName, //Pflicht Customer

            string geschlecht = "", string mobilNummer = "", string status = "", string ahvnummer = "", string wohnort = "", //Optional Person
            string nationality = "", string adresse = "", string postleitzahl = "", string telnrprivat = "", //Optional Person

            string businessAddress = "", string kundenTyp = "", string kundenKontakt = "") //Optional Customer

            : base(anrede, vorname, nachname, email, birthday, geschlecht, mobilNummer, status, ahvnummer,
                wohnort, nationality, adresse, postleitzahl, telnrprivat)
        {
            CustomerNumber = customerNumber;
            FirmenName = firmenName;
            BusinessAddress = businessAddress;
            KundenTyp = kundenTyp;
            Kundenkontakt = kundenKontakt;
        }

        //returns a DataRow of the Persons information that can be used for the DataTable
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
            return base.GetDataAsString() + ", " + CustomerNumber + ", " + FirmenName + ", " + BusinessAddress
                + ", " + KundenTyp + ", " + Kundenkontakt;
        }


    }
}

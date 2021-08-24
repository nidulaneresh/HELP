using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Person
    {
        //only used for Constructor, if no parameter is assigned
        private DateTime standard = new DateTime(2000, 1, 1);

        public string Anrede { get; set; } //Pflicht
        public string Vorname { get; set; } //Pflicht
        public string Nachname { get; set; } //Pflicht
        public string Email { get; set; } //Pflicht
        public DateTime Birthday { get; set; } //Pflicht (fürs erste, bis Problem mit DateTime gelöst ist)
        public string Geschlecht { get; set; }
        public string MobilNummer { get; set; }
        public string Status { get; set; } //Aktiv / Passiv
        public string AHVnummer { get; set; }
        public string Wohnort { get; set; }
        public string Nationality { get; set; }
        public string Adresse { get; set; }
        public string Postleitzahl { get; set; }
        public string TelefonnummerPrivat { get; set; }
        public static List<string> SalutationOptions { get; internal set; }
        public static List<string> GenderOptions { get; internal set; }
        public static List<string> StatusOptions { get; internal set; }

        public Person()
        {

        }

        //only used for test data, to be deleted
        public Person(string anrede, string vorname, string nachname, string email, //Pflicht
            DateTime birthday, string geschlecht = "", string mobilNummer = "", //Optional
            string status = "", string ahvnummer = "",
            string wohnort = "", string nationality = "", string adresse = "",
            string postleitzahl = "", string telnrprivat = "")
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
            Nationality = nationality;
            Adresse = adresse;
            Postleitzahl = postleitzahl;
            TelefonnummerPrivat = telnrprivat;
        }

        //returns a DataRow of the Persons information that can be used for the DataTable
        public virtual DataRow GetDataRow(DataTable table)
        {
            throw new System.NotImplementedException();
        }

        //Updating information saved in the object
        public virtual void Update()
        {

        }

        ///<summary>
        ///Compares two Persons (must be the same object type) and returns all differences collected as a string
        ///</summary>
        public static string Compare(Person thisPerson, Person otherPerson)
        {
            PropertyInfo[] thisProperties = thisPerson.GetType().GetProperties();
            string differences = "";

            //this if makes sure that you compare only objects of the same type (comparing Customers and Employees is not possible)
            if(thisPerson.GetType() == thisPerson.GetType())
            {
                //Iterates through all properties
                for (int i = 0; i < thisProperties.Length; i++)
                {
                    //If properties are different, returns string with differences
                    if (Convert.ToString(thisProperties[i].GetValue(thisPerson)) != Convert.ToString(thisProperties[i].GetValue(otherPerson)))
                    {
                        differences += thisProperties[i].Name + " changed from " + '"' + thisProperties[i].GetValue(thisPerson) + '"' + " to " + '"' + thisProperties[i].GetValue(otherPerson) + '"';

                        //Removes "," on last entry 
                        if(i < thisProperties.Length - 1)
                        {
                            differences += ", ";
                        }
                    }
                }
            }

            return differences;
        }

        //Check if two persons are exactly the same, returns a bool
        public virtual bool Equal(Person otherPerson)
        {
            return true;
        }

        public virtual string GetDataAsString()
        {
            return Anrede + ", " + Vorname + ", " + Nachname + ", " + Birthday + ", "
                + Geschlecht + ", " + MobilNummer + ", " + Email + ", " + Status + ", "
                + AHVnummer + ", " + Wohnort + ", " + Nationality + ", " + Adresse + ", " +
                Postleitzahl + ", " + TelefonnummerPrivat;
        }
    }
}

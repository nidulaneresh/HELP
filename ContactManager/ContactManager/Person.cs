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
        //Options for ComboBox
        private static readonly List<string> salutationOptions = new List<string>() { "Frau", "Herr", "Divers" };
        private static readonly List<string> genderOptions = new List<string>() { "männlich", "weiblich", "divers" };
        private static readonly List<string> statusOptions = new List<string>() { "aktiv", "inaktiv" };

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
        public static List<string> SalutationOptions { get { return salutationOptions; } set { } }
        public static List<string> GenderOptions { get { return genderOptions; } set { } }
        public static List<string> StatusOptions { get { return statusOptions; } set { } }

        public Person()
        {

        }

        //returns a DataRow of the Persons information that can be used for the DataTable
        public virtual DataRow GetDataRow(DataTable table)
        {
            throw new System.NotImplementedException();
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

        ///<summary>
        ///Returns all properties as string. Useful for debugging.
        ///</summary>
        public virtual string GetDataAsString()
        {
            return Anrede + ", " + Vorname + ", " + Nachname + ", " + Birthday + ", "
                + Geschlecht + ", " + MobilNummer + ", " + Email + ", " + Status + ", "
                + AHVnummer + ", " + Wohnort + ", " + Nationality + ", " + Adresse + ", " +
                Postleitzahl + ", " + TelefonnummerPrivat;
        }
    }
}

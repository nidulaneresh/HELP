using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ContactManager
{
    //Should handle all communication to the hard drive (load, save..)
    public class Disk
    {
        //private property path
        private static string _diskPath = @"C:\ContactManager\";

        //Saves the ContactBook Object to the disk
        public static void Save(ContactBook contactBook)
        {
            var file = CreateDirectoryAndFile("contactbook.json");
            string jsonString = JsonConvert.SerializeObject(contactBook, Formatting.Indented);
            File.WriteAllText(file, jsonString);
        }

        //Saves the ContactDoc Object to the disk
        public static void Save(ContactDoc contactDoc)
        {
            var file = CreateDirectoryAndFile("contactdoc.json");
            string jsonString = JsonConvert.SerializeObject(contactDoc, Formatting.Indented);
            File.WriteAllText(file, jsonString);
        }

        //Saves the ContactDoc Object to the disk
        public static void Save(List<ContactDoc> contactDocs)
        {
            var file = CreateDirectoryAndFile("contactdoc.json");
            string jsonString = JsonConvert.SerializeObject(contactDocs, Formatting.Indented);
            File.WriteAllText(file, jsonString);
        }

        //Loads the ContactBook from the disk
        public static ContactBook Load()
        {
            var file = CreateDirectoryAndFile("contactbook.json");

            using (StreamReader r = new StreamReader(file))
            {
              ContactBook items;
              string json = r.ReadToEnd();
              items = JsonConvert.DeserializeObject<ContactBook>(json);
              return items;
            }
        }

        //Loads the ContactBook from the disk
        public static List<ContactDoc> LoadContactDocs()
        {
            var file = CreateDirectoryAndFile("contactdoc.json");

            using (StreamReader r = new StreamReader(file))
            {
              List<ContactDoc> items;
              string json = r.ReadToEnd();
              items = JsonConvert.DeserializeObject<List<ContactDoc>>(json);
              return items;
            }
        }

        private static string CreateDirectoryAndFile(string fileName) 
        {
            if (!Directory.Exists(_diskPath))
            {
              Directory.CreateDirectory(_diskPath);
              File.Create(Path.Combine(_diskPath, fileName)).Close();
            }

            return Path.Combine(_diskPath, fileName);
        }

        //Saves the initial contacdoc data to the disk
        public static void SaveContactDocInitialData()
        {
            var listContactDocs = new List<ContactDoc>();

            ContactDoc contactDoc = new ContactDoc(
              1,
              new Customer("Herr", "Alexander", "Himmel", "alexander.himmel@gmail.com", new DateTime(1997, 7, 18), 1, "Habicht AG"),
              new Employee("Herr", "Steffen", "Eisenberg", "steffen.eisenberg@gmail.com", new DateTime(1994, 3, 2), 1, new DateTime(2015, 1, 3), new DateTime(1980, 1, 1), "100%"),
              "notest askldfjasldkfjasdkfjaskdf",
              DateTime.Now);

            ContactDoc contactDoc2 = new ContactDoc(
              2,
              new Customer("Frau", "Schulze", "Lena", "lena.schulze@gmail.com", new DateTime(1987, 5, 13), 2, "Kugel GmbH"),
              new Employee("Herr", "Swen", "Zimmermann", "swen.zimmermann@gmail.com", new DateTime(1996, 5, 7), 2, new DateTime(2013, 4, 21), new DateTime(1980, 1, 1), "100%"),
              "notest askldfjasldkfjasdkfjaskdf",
              DateTime.Now);

            ContactDoc contactDoc3 = new ContactDoc(
              3,
              new Customer("Frau", "Katrin", "Herz", "katrin.herz@gmail.com", new DateTime(2000, 9, 27), 3, "Schluckspecht Inc."),
              new Employee("Frau", "Juliane", "Baier", "juliane.baier@gmail.com", new DateTime(1987, 3, 12), 3, new DateTime(2018, 3, 12), new DateTime(1980, 1, 1), "80%"),
              "notest askldfjasldkfjasdkfjaskdf",
              DateTime.Now);
      
            listContactDocs.Add(contactDoc);
            listContactDocs.Add(contactDoc2);
            listContactDocs.Add(contactDoc3);

            Disk.Save(listContactDocs);
        }

        //Save the initial contact book to the disk
        public static void SaveContactBookInitialData()
        {
            ContactBook testContactBook = new ContactBook();

            testContactBook.Employees[1] = new Employee("Herr", "Steffen", "Eisenberg", "steffen.eisenberg@gmail.com", new DateTime(1994, 3, 2), 1, new DateTime(2015, 1, 3), new DateTime(1980, 1, 1), "100%");
            testContactBook.Employees[2] = new Employee("Herr", "Swen", "Zimmermann", "swen.zimmermann@gmail.com", new DateTime(1996, 5, 7), 2, new DateTime(2013, 4, 21), new DateTime(1980, 1, 1), "100%");
            testContactBook.Employees[3] = new Employee("Frau", "Juliane", "Baier", "juliane.baier@gmail.com", new DateTime(1987, 3, 12), 3, new DateTime(2018, 3, 12), new DateTime(1980, 1, 1), "80%");

            testContactBook.Employees[4] = new Trainee("Frau", "Antje", "Lang", "antje.lang@gmail.com", new DateTime(2003, 4, 17), 4, new DateTime(2019, 8, 1), new DateTime(1980, 1, 1), "100%", 4, 2);
            testContactBook.Employees[5] = new Trainee("Herr", "Stefan", "Keller", "stefan.keller@gmail.com", new DateTime(2002, 12, 3), 5, new DateTime(2018, 8, 2), new DateTime(1980, 1, 1), "100%", 3, 3);

            testContactBook.Employees[6] = new Employee("Frau", "Franziska", "Schweitzer", "franziska.schweitzer@gmail.com", new DateTime(1963, 11, 11), 6, new DateTime(2012, 1, 1), new DateTime(1980, 1, 1), "60%", "weiblich",
                "0786003020", "aktiv", "723.457.3756.30", "St. Gallen", "CH", "Sieberstrasse 13", "9000", "0764001040", "Hoheit", "0717274050", "0717274000", "R&D", "Head of R&D", 4);

            testContactBook.Employees[7] = new Trainee("Frau", "Mandy", "Roth", "mandy.roth@gmail.com", new DateTime(2001, 12, 1), 7, new DateTime(2019, 5, 1), new DateTime(1980, 1, 1), "100%", 4, 2, "weiblich",
                "0786003121", "aktiv", "732.467.3876.31", "Balgach", "CH", "Segerstrasse 16", "9436", "0764103069", "Stift", "0717274156", "0717274000", "Fertigung", "Lehrling CNC Fräsen", 0);

            testContactBook.Customers[1] = new Customer("Herr", "Alexander", "Himmel", "alexander.himmel@gmail.com", new DateTime(1997, 7, 18), 1, "Habicht AG");
            testContactBook.Customers[2] = new Customer("Frau", "Schulze", "Lena", "lena.schulze@gmail.com", new DateTime(1987, 5, 13), 2, "Kugel GmbH");
            testContactBook.Customers[3] = new Customer("Frau", "Katrin", "Herz", "katrin.herz@gmail.com", new DateTime(2000, 9, 27), 3, "Schluckspecht Inc.");

            testContactBook.Customers[4] = new Customer("Herr", "Jörg", "Reinhardt", "joerg.reinhardt@gmail.com", new DateTime(1988, 7, 16), 4, "Nutten AG", "männlich", "0795001245", "aktiv", "741.587.4126.80", "Zürich", "DE",
                "Schelmstrasse 3", "6000", "0717405060", "Hoheitstrasse 60", "Bester Kunde", "KundenKontakt");

            Disk.Save(testContactBook);
        }
    }
}

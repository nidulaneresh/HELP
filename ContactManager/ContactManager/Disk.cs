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
        private static string fileName = "contactbook.json";

        //Saves the ContactBook Object to the disk
        public static void Save(ContactBook contactBook)
        {
            var file = CreateDirectoryAndFile(fileName);
            string jsonString = JsonConvert.SerializeObject(contactBook, Formatting.Indented);
            File.WriteAllText(file, jsonString);
        }

        //Loads the ContactBook from the disk
        public static ContactBook Load()
        {
            var file = Path.Combine(_diskPath, fileName);
            if (!IsFileAvailable(fileName))
            {
                file = CreateDirectoryAndFile(fileName);
            }

            using (StreamReader r = new StreamReader(file))
            {
              ContactBook items;
              string json = r.ReadToEnd();
              items = JsonConvert.DeserializeObject<ContactBook>(json);
              return items;
            }
        }

        //Check if directy and file is available, create if necessary
        private static string CreateDirectoryAndFile(string fileName) 
        {
            if (!File.Exists(_diskPath + fileName))
            {
              Directory.CreateDirectory(_diskPath);
              File.Create(Path.Combine(_diskPath, fileName)).Close();
            }

            return Path.Combine(_diskPath, fileName);
        }

        //Check only if file is available
        private static bool IsFileAvailable(string fileName)
        {
            if (File.Exists(_diskPath + fileName))
            {
                return true;
            }
            return false;
        }
    }
}

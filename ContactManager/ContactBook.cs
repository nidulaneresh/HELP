using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ContactBook
    {
        public int EmployeeCounter { get; set; }

        public int CustomerCounter { get; set; }

        public int ContactDocCounter { get; set; }
        
        //List of all employees, including trainees
        public Dictionary<int, Employee> Employees { get; set; }

        //List of all customers
        public Dictionary<int, Customer> Customers { get; set; }

        //List of all contact documentations
        public Dictionary<int, ContactDoc> ContactDocs { get; set; }

        //has Lists for changes on employees, customers and contact documentation in it (as strings)
        //not sure if this makes sense.. see as well History.cs (maybe it makes more sense to collect History elements?)
        public History History { get; set; }

        public ContactBook()
        {
            Employees = new Dictionary<int, Employee>();
            Customers = new Dictionary<int, Customer>();
            ContactDocs = new Dictionary<int, ContactDoc>();

            EmployeeTable = new DataTable();
            DefineEmployeeTable();
            EmployeeCounter = 0;

            CustomerTable = new DataTable();
            DefineCustomerTable();
            CustomerCounter = 0;

            ContactDocTable = new DataTable();
            DefineContactDocTable();
            ContactDocCounter = 0;

            History = new History();
        }


        //Table includes Trainees
        public DataTable EmployeeTable { get; set; }

        public DataTable CustomerTable { get; set; }

        public DataTable ContactDocTable { get; set; }

        private void DefineEmployeeTable()
        {
            EmployeeTable.Columns.Add("EmployeeNumber", typeof(Int32));             //0
            EmployeeTable.Columns.Add("Salutation", typeof(String));                //1
            EmployeeTable.Columns.Add("Firstname", typeof(String));                 //2
            EmployeeTable.Columns.Add("Lastname", typeof(String));                  //3
            EmployeeTable.Columns.Add("Birthday", typeof(DateTime));                //4
            EmployeeTable.Columns.Add("Gender", typeof(String));                    //5
            EmployeeTable.Columns.Add("Mobile Number", typeof(String));             //6
            EmployeeTable.Columns.Add("eMail", typeof(String));                     //7
            EmployeeTable.Columns.Add("Status", typeof(String));                    //8
            EmployeeTable.Columns.Add("AHV Number", typeof(String));                //9
            EmployeeTable.Columns.Add("Location", typeof(String));                  //10
            EmployeeTable.Columns.Add("Nationality", typeof(String));               //11
            EmployeeTable.Columns.Add("Adress", typeof(String));                    //12
            EmployeeTable.Columns.Add("Zip Code", typeof(String));                  //13
            EmployeeTable.Columns.Add("Phone Number Privat", typeof(String));       //14
            EmployeeTable.Columns.Add("Phone Number Business", typeof(String));     //15
            EmployeeTable.Columns.Add("Fax Number", typeof(String));                //16
            EmployeeTable.Columns.Add("Titel", typeof(String));                     //17
            EmployeeTable.Columns.Add("Division", typeof(String));                  //18
            EmployeeTable.Columns.Add("Date of Entry", typeof(DateTime));           //19
            EmployeeTable.Columns.Add("Date of Exit", typeof(DateTime));            //20
            EmployeeTable.Columns.Add("Employeement Level", typeof(String));        //21
            EmployeeTable.Columns.Add("Role", typeof(String));                      //22
            EmployeeTable.Columns.Add("Cadre Level", typeof(String));               //23
            EmployeeTable.Columns.Add("Max Trainee Years", typeof(String));         //24
            EmployeeTable.Columns.Add("Current Traine Year", typeof(String));       //25
        }

        private void DefineCustomerTable()
        {
            CustomerTable.Columns.Add("Customer Number", typeof(Int32));
            CustomerTable.Columns.Add("Salutation", typeof(String));
            CustomerTable.Columns.Add("Firstname", typeof(String));
            CustomerTable.Columns.Add("Lastname", typeof(String));
            CustomerTable.Columns.Add("Birthday", typeof(DateTime));
            CustomerTable.Columns.Add("Gender", typeof(String));
            CustomerTable.Columns.Add("Mobile Number", typeof(String));
            CustomerTable.Columns.Add("eMail", typeof(String));
            CustomerTable.Columns.Add("Status", typeof(String));
            CustomerTable.Columns.Add("AHV Number", typeof(String));
            CustomerTable.Columns.Add("Location", typeof(String));
            CustomerTable.Columns.Add("Nationality", typeof(String));
            CustomerTable.Columns.Add("Adress", typeof(String));
            CustomerTable.Columns.Add("Zip Code", typeof(String));
            CustomerTable.Columns.Add("Phone Number Privat", typeof(String));
            CustomerTable.Columns.Add("Company", typeof(String));
            CustomerTable.Columns.Add("Business-Adress", typeof(String));
            CustomerTable.Columns.Add("Customer Type", typeof(String));
            CustomerTable.Columns.Add("Customer Contact", typeof(String));
        }

        private void DefineContactDocTable()
        {
          ContactDocTable = new DataTable();
          ContactDocTable.Columns.Add("ID", typeof(int));
          ContactDocTable.Columns.Add("Kunde", typeof(string));
          ContactDocTable.Columns.Add("Mitarbeiter", typeof(string));
          ContactDocTable.Columns.Add("Datum", typeof(DateTime));
          ContactDocTable.Columns.Add("Zeit", typeof(string));
          ContactDocTable.Columns.Add("Notizen", typeof(string));
        }

        public void FillEmployeeTable()
        {
            foreach (KeyValuePair<int, Employee> employeePair in Employees)
            {
                EmployeeTable.Rows.Add(employeePair.Value.GetDataRow(EmployeeTable));
                EmployeeCounter++;
            }
        }

        public void FillContactDocTable()
        {
            //clear
            ContactDocTable.Clear();

            foreach (var conDoc in ContactDocs)
            {
              ContactDocTable.Rows.Add
                (
                conDoc.Value.Id,
                conDoc.Value.Kunde.Vorname + " " + conDoc.Value.Kunde.Nachname,
                conDoc.Value.Mitarbeiter.Vorname + " " + conDoc.Value.Mitarbeiter.Nachname,
                conDoc.Value.Datum,
                conDoc.Value.Zeit,
                conDoc.Value.Notes
                );
            }
        }
    }
}

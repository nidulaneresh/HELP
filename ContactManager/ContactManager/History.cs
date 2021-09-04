using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    public class History
    {
        //List of changes made on the customer database
        public List<string> CustomerHistory { get; set; }

        //List of changes made on the employee database (including trainees)
        public List<string> EmployeeHistory { get; set; }

        //List of changes made on the contact documentation database
        public List<string> ContactDocHistory { get; set; }

        public History()
        {
            EmployeeHistory = new List<string>();
            ContactDocHistory = new List<string>();
            CustomerHistory = new List<string>();
        }

        ///<summary>
        ///Create and add history entry if a new employee gets created
        ///</summary>
        public void NewEmployee(Employee employee)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Employee No. " + employee.EmployeeNumber + ": Added";
            EmployeeHistory.Add(historyEntry);
        }

        ///<summary>
        ///Create and add history entry if an employee is changed. Lists changes
        ///</summary>
        public void UpdatedEmployee(Employee oldEmployee, Employee newEmployee)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Employee No. " + oldEmployee.EmployeeNumber + ": " + Person.Compare(oldEmployee, newEmployee);

            if (Person.Compare(oldEmployee, newEmployee) != String.Empty)
            {
                EmployeeHistory.Add(historyEntry);
            }
        }

        ///<summary>
        ///Create and add history entry if an employee is deleted
        ///</summary>
        public void DeletedEmployee(Employee employee)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Employee No. " + employee.EmployeeNumber + ": Deleted";
            EmployeeHistory.Add(historyEntry);
        }

        ///<summary>
        ///Create and add history entry if a new contactDoc gets created
        ///</summary>
        public void NewContactDoc(ContactDoc contactDoc)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - ContactDoc No. " + contactDoc.Id + ": Added";
            ContactDocHistory.Add(historyEntry);
        }

        ///<summary>
        ///Create and add history entry if a contactDoc is changed. Lists changes
        ///</summary>
        public void UpdatedContactDoc(ContactDoc oldContactDoc, ContactDoc newContactDoc)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - ContactDoc No. " + oldContactDoc.Id + ": " + ContactDoc.Compare(oldContactDoc, newContactDoc);

            if (ContactDoc.Compare(oldContactDoc, newContactDoc) != String.Empty)
            {
                ContactDocHistory.Add(historyEntry);
            }
        }

        ///<summary>
        ///Create and add history entry if a contactDoc is deleted
        ///</summary>
        public void DeletedContactDoc(ContactDoc contactDoc)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - ContactDoc No. " + contactDoc.Id + ": Deleted";
            ContactDocHistory.Add(historyEntry);
        }

        ///<summary>
        ///Create and add history entry if a new customer gets created
        ///</summary>
        public void NewCustomer(Customer customer)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Customer No. " + customer.CustomerNumber + ": Added";
            CustomerHistory.Add(historyEntry);
        }

        ///<summary>
        ///Create and add history entry if a customer is changed. Lists changes
        ///</summary>
        public void UpdatedCustomer(Customer oldCustomer, Customer newCustomer)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Customer No. " + oldCustomer.CustomerNumber + ": " + Person.Compare(oldCustomer, newCustomer);

            if (Person.Compare(oldCustomer, newCustomer) != String.Empty)
            {
                CustomerHistory.Add(historyEntry);
            }
        }

        ///<summary>
        ///Create and add history entry if a customer is deleted
        ///</summary>
        public void DeletedCustomer(Customer customer)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Customer No. " + customer.CustomerNumber + ": Deleted";
            CustomerHistory.Add(historyEntry);
        }

        ///<summary>
        ///Combines all historyEntries into one string (each entry is one line)
        ///</summary>
        public string UpdateHistoryTextField(List<string> historyList)
        {
            string history = "";

            if (historyList.Count != 0)
            {
                for (int i = historyList.Count - 1; i >= 0; i--)
                {
                    history += historyList[i] + "\r\n";
                }
            }

            return history;
        }

    }
}

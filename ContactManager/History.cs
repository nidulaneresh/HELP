using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        
        public void NewEmployee(Employee employee)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Employee No. " + employee.EmployeeNumber + ": Added";
            EmployeeHistory.Add(historyEntry);
        }

        public void UpdatedEmployee(Employee oldEmployee, Employee newEmployee)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Employee No. " + oldEmployee.EmployeeNumber + ": " + Person.Compare(oldEmployee, newEmployee);
            EmployeeHistory.Add(historyEntry);
        }

        public void DeletedEmployee(Employee employee)
        {
            string historyEntry = DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " - Employee No. " + employee.EmployeeNumber + ": Deleted";
            EmployeeHistory.Add(historyEntry);
        }


    }
}

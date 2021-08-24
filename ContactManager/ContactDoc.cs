using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ContactDoc
    {
        //Properties
        public int Id { get; set; }

        public Customer Kunde { get; set; }

        public Employee Mitarbeiter { get; set; }

        public DateTime Datum { get; set; }

        public string Zeit { get; set; }

        public string Notes { get; set; }

        //Constructor
        public ContactDoc(int id, Customer customer, Employee mitarbeiter, string notes, DateTime datum)
        {
            Id = id;
            Kunde = customer;
            Mitarbeiter = mitarbeiter;
            Notes = notes;
            Datum = datum.Date;
            Zeit = datum.ToString("HH:mm");
        }

        //GetDataRow
        public DataRow GetDataRow(DataTable table)
        {
            DataRow row = table.NewRow();

            row[0] = this.Id;
            row[1] = this.Kunde;
            row[2] = this.Mitarbeiter;
            row[3] = this.Datum;
            row[4] = this.Zeit;
            row[5] = this.Notes;

            return row;
        }

        //JoinData
        public ContactDoc JoinData()
        {
            //todo
            return null;
        }

        //Updating information saved in the object
        public void Update()
        {
            //todo
        }
    }
}

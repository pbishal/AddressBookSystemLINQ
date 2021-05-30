using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLinq
{
    class AddressBookDataTable
    {// UC1 Created new address book table

        public static DataTable table = new DataTable();

        /// UC2 Adds the data into table.
        /// </summary>
        public static void AddDataIntoTable()
        {

            //Adding columns 
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(int));
            table.Columns.Add("PhoneNumber", typeof(double));
            table.Columns.Add("Email", typeof(string));

            ///Adding First Name and Last name as primary key
            DataColumn[] primaryKeys = new DataColumn[2];
            primaryKeys[0] = table.Columns["FirstName"];
            primaryKeys[1] = table.Columns["LastName"];
            table.PrimaryKey = primaryKeys;
        }
    }
}
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

            ///Adding rows
            table.Rows.Add("Prateek", "Dash", "patia", "Bhubaneswar", "Odiha", 700658, "9436588969", "dprat@gmail.com");
            table.Rows.Add("Shailesh", "Satapathy", "BN", "Ganjam", "Odisha", 700528, "7008945698", "shailesh@gmail.com");
            table.Rows.Add("Niraj", "Kumar", "Narwa", "Jamshedpur", "Jharkhand", 755258, "9656322121", "niraj@gmail.com");
            table.Rows.Add("Prabhat", "Kumar", "Sasa", "Sasaram", "Bihar", 569696, "6966544858", "prabhat@gmail.com");
            table.Rows.Add("Abhishek", "Dalai", "BN", "Bhubaneswar", "Odisha", 700856, "9658544521", "abhishek@gmail.com");
            //Printing data
            Console.WriteLine("\nDataTable contents:");
            foreach (var record in table.AsEnumerable())
            {
                Console.WriteLine("FirstName: " + "\t" + record.Field<string>("FirstName") + "\t" + "LastName: " + "\t" + record.Field<string>("LastName") + "\t" + "Address: " + record.Field<string>("Address") + "\t" + "City: " + record.Field<string>("City") + "\t" + " State: " + record.Field<string>("State") + "\t" + "Zip: " + record.Field<int>("Zip") + "\t" + " PhoneNumber: " + record.Field<double>("PhoneNumber") + "\t" + "EmailID: " + record.Field<string>("Email"));
            }
        }
    }
}
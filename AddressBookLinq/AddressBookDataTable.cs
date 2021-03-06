using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLinq
{
    class AddressBookDataTable
    {
        // UC1 Created new address book table

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
            table.Rows.Add("Prateek", "Dash", "patia", "Bhubaneswar", "Odisha", 700658, "9436588969", "dprat@gmail.com");
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
        //UC4 Editing exiting Contact Details.
        public static void EditExistingContactDetails(string firstName, string lastName, int zip)
        {
            Console.WriteLine("\n Edit existing contacts details");
            (from p in table.AsEnumerable()
             where p.Field<string>("FirstName") == firstName && p.Field<string>("LastName") == lastName
             select p).ToList().ForEach(x => x[5] = zip);
            //Printing data
            Console.WriteLine("\nDataTable contents:");
            foreach (var record in table.AsEnumerable())
            {
                Console.WriteLine("FirstName: " + "\t" + record.Field<string>("FirstName") + "\t" + "LastName: " + "\t" + record.Field<string>("LastName") + "\t" + "Address: " + record.Field<string>("Address") + "\t" + "City: " + record.Field<string>("City") + "\t" + " State: " + record.Field<string>("State") + "\t" + "Zip: " + record.Field<int>("Zip") + "\t" + " PhoneNumber: " + record.Field<double>("PhoneNumber") + "\t" + "EmailID: " + record.Field<string>("Email"));
            }
        }

        // UC5 Delete Person Contact Using Name.

        public static void DeleteContactUsingName()
        {
            //Retrieve the datarow containing given name
            var records = (from p in table.AsEnumerable()
                           where p.Field<string>("FirstName").Equals("Prabhat") && p.Field<string>("LastName").Equals("Kumar")
                           select p).FirstOrDefault();
            //Delete the row
            records.Delete();
            //Printing data
            Console.WriteLine("\nDataTable contents:");
            foreach (var record in table.AsEnumerable())
            {
                Console.WriteLine("FirstName: " + "\t" + record.Field<string>("FirstName") + "\t" + "LastName: " + "\t" + record.Field<string>("LastName") + "\t" + "Address: " + record.Field<string>("Address") + "\t" + "City: " + record.Field<string>("City") + "\t" + " State: " + record.Field<string>("State") + "\t" + "Zip: " + record.Field<int>("Zip") + "\t" + " PhoneNumber: " + record.Field<double>("PhoneNumber") + "\t" + "EmailID: " + record.Field<string>("Email"));
            }
        }

        // UC6 Retrieving Contact Details By State Or City Name.

        public static void RetrievingContactDetailsByCityOrState()
        {
            var retrieveData = from records in table.AsEnumerable()
                               where (records.Field<string>("City").Equals("Bhubaneswar") || records.Field<string>("State").Equals("Odisha"))
                               select records;
            //Printing data
            Console.WriteLine("\nRetrieved contactact details by city or state name :");
            foreach (var record in retrieveData)
            {
                Console.WriteLine("FirstName: " + "\t" + record.Field<string>("FirstName") + "\t" + "LastName: " + "\t" + record.Field<string>("LastName") + "\t" + "Address: " + record.Field<string>("Address") + "\t" + "City: " + record.Field<string>("City") + "\t" + " State: " + record.Field<string>("State") + "\t" + "Zip: " + record.Field<int>("Zip") + "\t" + " PhoneNumber: " + record.Field<double>("PhoneNumber") + "\t" + "EmailID: " + record.Field<string>("Email"));
            }
        }

        // UC7 Get the count of number of contacts as per the state or city.

        public static void GetCountOfContactInCityOrState()
        {
            Console.WriteLine("\n Get Count by city ");
            var countAsPerCity = (from records in table.AsEnumerable()
                                  group records by records.Field<string>("City") into Group
                                  select new { City = Group.Key, NumberOfContacts = Group.Count() });
            foreach (var record in countAsPerCity)
            {
                Console.WriteLine($"City : {record.City}, Number Of Contacts : {record.NumberOfContacts}");
            }
            Console.WriteLine("\n Get count by state ");
            var countAsPerState = (from records in table.AsEnumerable()
                                   group records by records.Field<string>("State") into Group
                                   select new { State = Group.Key, NumberOfContacts = Group.Count() });
            foreach (var record in countAsPerState)
            {
                Console.WriteLine($"City : {record.State}, Number Of Contacts : {record.NumberOfContacts}");
            }
        }

        // UC8 Retrieves the records sorted by name for a given city.

        public static void SortedContactsByNameForAgivenCity(string City)
        {
            Console.WriteLine("Sorting by name for City");
            var retrievedData = from records in table.AsEnumerable()
                                where records.Field<string>("City") == City
                                orderby records.Field<string>("FirstName"), records.Field<string>("LastName")
                                select records;
            ///Print Data
            foreach (var record in retrievedData)
            {
                Console.WriteLine("FirstName: " + "\t" + record.Field<string>("FirstName") + "\t" + "LastName: " + "\t" + record.Field<string>("LastName") + "\t" + "Address: " + record.Field<string>("Address") + "\t" + "City: " + record.Field<string>("City") + "\t" + " State: " + record.Field<string>("State") + "\t" + "Zip: " + record.Field<int>("Zip") + "\t" + " PhoneNumber: " + record.Field<double>("PhoneNumber") + "\t" + "EmailID: " + record.Field<string>("Email"));
            }
        }
    }
}
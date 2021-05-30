using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Addressbook System Using Linq");
            //AddressBookDataTable.AddDataIntoTable();
            //AddressBookDataTable.EditExistingContactDetails("Prabhat", "Kumar", 751030);
            //AddressBookDataTable.DeleteContactUsingName();
            AddressBookDataTable.RetrievingContactDetailsByCityOrState();
            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ModifyProductsByReference();
            Console.ReadLine();
        }

        class Product
        {
            public Product(string name, int newID)
            {
                ItemName = name;
                ItemID = newID;
            }

            public string ItemName { get; set; }
            public int ItemID { get; set; }
        }

        private static void ChangeByReference(Product itemRef)
        {
            itemRef.ItemID = 1;
            // Change the address that is stored in the itemRef parameter.
            itemRef = new Product("Stapler", 99999);

            // You can change the value of one of the properties of
            // itemRef. The change happens to item in Main as well.
            itemRef.ItemID = 12345;
        }

        private static void ModifyProductsByReference()
        {
            // Declare an instance of Product and display its initial values.
            Product item = new Product("Fasteners", 54321);
            System.Console.WriteLine("Original values in Main.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);

            // Pass the product instance to ChangeByReference.
            ChangeByReference(item);
            System.Console.WriteLine("Back in Main.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);
        }
    }
}

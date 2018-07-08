using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter6
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Contact contact = new Contact();
            //contact.Name = "Inigo Montoya";

            // System.Console.WriteLine(contact.Name);

            // 보호 수준으로 인해 액세스하지 못함
            // contact.ObjectKey = Guid.NewGuid();

            Contact contact;
            PdaItem item;

            contact = new Contact();
            item = contact;

            item.Name = "Inigo Montoya";

            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
        }
    }
}

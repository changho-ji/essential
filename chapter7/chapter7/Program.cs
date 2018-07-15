using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter7
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact[] contacts = new Contact[3];
            contacts[0] = new Contact
            (
                "Dick",
                "Traci",
                "123 Main St., Spokane, WA 99037",
                "123-123-1234"
            );
            contacts[1] = new Contact
            (
                "Andrew",
                "Littman",
                "1417 Palmary St., Dallas, TX 55555",
                "555-123-4567"
            );
            contacts[2] = new Contact
            (
                "Mary",
                "Hartfelt",
                "1520 Thunder Way, Elizabethton, PA 44444",
                "444-123-4567"
            );

            ConsoleListControl.List(Contact.Headers, contacts);

            Console.WriteLine();

            Publication[] publications = new Publication[2]
            {
                new Publication(
                    "Celebration of Discipline",
                    "Richard Foster",
                    1978
                    ),
                new Publication(
                    "Orthodoxy",
                    "G.K. Chesterton",
                    1908
                    )
            };

            ConsoleListControl.List(Publication.Headers, publications);
        }
    }
}
